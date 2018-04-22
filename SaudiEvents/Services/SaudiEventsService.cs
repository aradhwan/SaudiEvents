using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaudiEvents.Models;
using SaudiEvents.Util;

namespace SaudiEvents.Services
{
    public class SaudiEventsService
    {
        readonly string serverURL = ServerURL.GetURL();

        public SaudiEventsService()
        {
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(serverURL);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return (client);
        }

        public async Task<List<Event>> GetEvents(DateTime FromDate, DateTime ToDate, string Lang="en", int PageSize=6000, 
                                                 string CategoryID="0", int CityID=0, string EventId="", string EventTitle=null,
                                                int RegionID=0, int StartIndex=0)
        {
            try
            {
                var client = GetClient();
                string FormattedFromDate = String.Format("{0:ddd MMM dd yyyy}", FromDate);
                string FormattedToDate = String.Format("{0:ddd MMM dd yyyy}", ToDate);
                var eventsRequest = new EventsRequest
                 {
                    categoryID = CategoryID,
                    cityID = CityID,
                    eventId = EventId,
                    eventTitle = EventTitle,
                    fromDate = FormattedFromDate,
                    lang = Lang,
                    pageSize = PageSize,
                    regionID = RegionID,
                    startIndex = StartIndex,
                    toDate = FormattedToDate
                 };
                var SerializedRequest = JsonConvert.SerializeObject(eventsRequest);
                HttpContent content = new StringContent(SerializedRequest, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/api/EventCalendar/SearchEvents", content).Result;
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    ResponseObject responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseString);
                    return responseObject.Records;
                }
                else
                {
                    return new List<Event>();
                }
            }
            catch (Exception)
            {
                return new List<Event>();
            }
        }
    }
}

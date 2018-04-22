using System;
namespace SaudiEvents.Models
{
    public class EventsRequest
    {
        public string categoryID { get; set; }
        public int cityID { get; set; }
        public string eventId { get; set; }
        public string eventTitle { get; set; }
        public string fromDate { get; set; }
        public string lang { get; set; }
        public int pageSize { get; set; }
        public int regionID { get; set; }
        public int startIndex { get; set; }
        public string toDate { get; set; }
    }
}

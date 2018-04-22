using System;
using System.Collections.Generic;

namespace SaudiEvents.Models
{
    public class ResponseObject
    {
        public string Result { get; set; }
        public List<Event> Records { get; set; }
    }
}

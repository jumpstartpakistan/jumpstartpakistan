using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JumpStartPakistan.Web.Areas.Admin.Models
{
    public class Event
    {
        public Event()
        {
            CreationDate = DateTime.Now;
            Date = DateTime.Now;
        }
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public bool isActive { get; set; }
        public bool isAvailable { get; set; }
        public EventManager Manager { get; set; }
        public Organizer Organizer { get; set; }
        public Host Host { get; set; }
        public string RegisterationLink { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
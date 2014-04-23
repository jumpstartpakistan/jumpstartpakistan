using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JumpStartPakistan.Domain.Entities
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
        public int? ManagerId { get; set; }
        public Organizer Organizer { get; set; }
        public int? OrganizerId { get; set; }
        public Host Host { get; set; }
        public int? HostId { get; set; }

        public string RegisterationLink { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
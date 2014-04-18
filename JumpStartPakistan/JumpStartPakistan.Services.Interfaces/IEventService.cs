using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();
        IEnumerable<Event> GetEvents(bool isArchived);
        Event GetEventById(int id);
        bool Add(Event nEvent);
    }
}

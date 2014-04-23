using JumpStartPakistan.Data.Repositories;
using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Services.Interfaces
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;

        public EventService()
            : this(new EventRepository())
        {

        }

        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public IEnumerable<Event> Get()
        {
            var events = _eventRepo.Get().ToList();
            events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return events;
        }

        public IEnumerable<Event> Get(bool isArchived)
        {

            var events = _eventRepo.Find(x => x.isAvailable == isArchived).ToList();
            events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return events;
        }

        public Event Get(int id)
        {
            var evt =  _eventRepo.Get(id);
            evt.isAvailable = evt.Date > DateTime.Now ? true : false;
            return evt;
        }

        public bool Add(Event nEvent)
        {
            bool isDone = false;

            _eventRepo.Add(nEvent);
            isDone = true;

            return isDone;
            //if (nEvent.EventId > 0)
            //{
            //    _eventRepo.Add(nEvent);
            //    isDone = true;
            //}
            //else {
            //    var fEvent = _eventRepo.Get(nEvent.EventId);
                
            //    isDone = true;
            //}
        }

        public bool Remove(int id)
        {
            bool isDone = false;

            _eventRepo.Remove(id);
            isDone = true;

            return isDone;            
        }
    }
}

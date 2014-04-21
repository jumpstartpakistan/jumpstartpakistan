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
    public class EventManagerService : IEventManagerService
    {
        private readonly IEventManagerRepository _eventManagerRepo;

        public EventManagerService()
            : this(new EventManagerRepository())
        {

        }

        public EventManagerService(IEventManagerRepository eventRepo)
        {
            _eventManagerRepo = eventRepo;
        }

        public IEnumerable<EventManager> Get()
        {
            return _eventManagerRepo.Get();
        }



        public EventManager Get(int id)
        {
            return _eventManagerRepo.Get(id);
        }

        public bool Add(EventManager nEvent)
        {
            bool isDone = false;

            _eventManagerRepo.Add(nEvent);
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

            _eventManagerRepo.Remove(id);
            isDone = true;

            return isDone;            
        }
    }
}

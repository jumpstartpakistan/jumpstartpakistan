using JumpStartPakistan.Data.Repositories;
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

        public EventService() : this( new EventRepository())
        {

        }

        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        IEnumerable<Domain.Entities.Event> IEventService.GetEvents()
        {
            return _eventRepo.Get();
        }

        IEnumerable<Domain.Entities.Event> IEventService.GetEvents(bool isArchived)
        {

            return _eventRepo.Find(x => x.isAvailable == isArchived);

        }

        Domain.Entities.Event IEventService.GetEventById(int id)
        {
            return _eventRepo.Get(id);
        }
    }
}

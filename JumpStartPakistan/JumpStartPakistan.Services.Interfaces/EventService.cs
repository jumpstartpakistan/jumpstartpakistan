﻿using JumpStartPakistan.Data.Repositories;
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
            return _eventRepo.Get();
        }

        public IEnumerable<Event> Get(bool isArchived)
        {

            return _eventRepo.Find(x => x.isAvailable == isArchived);

        }

        public Event Get(int id)
        {
            return _eventRepo.Get(id);
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

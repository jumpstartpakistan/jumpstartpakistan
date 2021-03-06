﻿using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> Get();
        IEnumerable<Event> Get(bool isArchived);
        Event Get(int id);
        bool Add(Event nEvent);
        bool Remove(int id);
    }
}

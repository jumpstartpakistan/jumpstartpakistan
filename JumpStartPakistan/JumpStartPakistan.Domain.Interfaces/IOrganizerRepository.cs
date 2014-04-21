﻿using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Domain.Interfaces
{
    public interface IOrganizerRepository
    {
        IEnumerable<Organizer> Get();
        Organizer Get(int id);

        void Add(Organizer nEvent);

        void Remove(int id);


        IEnumerable<Organizer> Find(Expression<Func<Organizer, bool>> predicate);
    }

   
}

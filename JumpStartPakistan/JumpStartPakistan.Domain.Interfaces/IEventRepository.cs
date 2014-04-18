using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Domain.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> Get();
        Event Get(int id);

        IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate);
    }

   
}

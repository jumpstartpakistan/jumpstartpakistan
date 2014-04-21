using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Domain.Interfaces
{
    public interface IEventManagerRepository
    {
        IEnumerable<EventManager> Get();
        EventManager Get(int id);

        void Add(EventManager eventManager);

        void Remove(int id);        

        IEnumerable<EventManager> Find(Expression<Func<EventManager, bool>> predicate);
    }

   
}

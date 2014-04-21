using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Domain.Interfaces
{
    public interface IHostRepository
    {
        IEnumerable<Host> Get();
        Host Get(int id);

        void Add(Host nEvent);

        void Remove(int id);


        IEnumerable<Host> Find(Expression<Func<Host, bool>> predicate);
    }

   
}

using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Services.Interfaces
{
    public interface IEventManagerService
    {
        IEnumerable<EventManager> Get();

        EventManager Get(int id);
        bool Add(EventManager eventManager);
        bool Remove(int id);
    }
}

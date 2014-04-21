using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Services.Interfaces
{
    public interface IHostService
    {
        IEnumerable<Host> Get();

        Host Get(int id);
        bool Add(Host host);
        bool Remove(int id);
    }
}

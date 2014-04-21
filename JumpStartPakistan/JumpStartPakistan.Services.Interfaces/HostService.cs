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
    public class HostService : IHostService
    {
        private readonly IHostRepository _hostRepo;

        public HostService()
            : this(new HostRepository())
        {

        }

        public HostService(IHostRepository eventRepo)
        {
            _hostRepo = eventRepo;
        }

        public IEnumerable<Host> Get()
        {
            return _hostRepo.Get();
        }



        public Host Get(int id)
        {
            return _hostRepo.Get(id);
        }

        public bool Add(Host host)
        {
            bool isDone = false;

            _hostRepo.Add(host);
            isDone = true;

            return isDone;
           
        }

        public bool Remove(int id)
        {
            bool isDone = false;

            _hostRepo.Remove(id);
            isDone = true;

            return isDone;            
        }
    }
}

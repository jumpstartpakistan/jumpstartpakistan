using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Data.Repositories
{
    public class HostRepository :IHostRepository
    {
        private readonly JumpStartPakistanDataContext _ctx;

        #region construction
        public HostRepository()
            : this(new JumpStartPakistanDataContext())
        {

        }

        public HostRepository(JumpStartPakistanDataContext ctx)
        {
            _ctx = ctx;
        }
        #endregion


        public IEnumerable<Host> Get()
        {
            var hosts = _ctx.Hosts.ToList();

            return hosts;
        }

        public Host Get(int id)
        {
            var host = _ctx.Hosts.Where(x => x.HostId == id).FirstOrDefault();
            return host;
        }

        public IEnumerable<Host> Find(System.Linq.Expressions.Expression<Func<Domain.Entities.Host, bool>> predicate)
        {
            var hosts = _ctx.Hosts.Where(predicate).ToList();
            
            return hosts;
        }

        public void Add(Host host)
        {
            //bool isDone = false;
            var found = _ctx.Hosts.Where(x => x.HostId == host.HostId).FirstOrDefault();
            if (found == null)
            {
                found = _ctx.Hosts.Add(host);

            }
            else
            {
                var entry = _ctx.Entry(found);
                entry.OriginalValues.SetValues(found);
                entry.CurrentValues.SetValues(host);
            }
            
            _ctx.SaveChanges();
            //void isDone;
        }

        public void Remove(int id)
        {
            //bool isDone = false;
            var found = _ctx.Hosts.Where(x => x.HostId == id).FirstOrDefault();
            if (found != null)
            {
                found = _ctx.Hosts.Remove(found);

            }            

            _ctx.SaveChanges();
            //void isDone;
        }


    }
}

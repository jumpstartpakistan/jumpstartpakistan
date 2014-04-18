using JumpStartPakistan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Data.Repositories
{
    public class EventRepository :IEventRepository
    {
        private readonly JumpStartPakistanDataContext _ctx;

        #region construction
        public EventRepository()
            : this(new JumpStartPakistanDataContext())
        {

        }
        
        public EventRepository(JumpStartPakistanDataContext ctx)
        {
            _ctx = ctx;
        }
        #endregion


        IEnumerable<Domain.Entities.Event> IEventRepository.Get()
        {
            var events = _ctx.Events.Include("Host").Include("Manager").Include("Organizer").ToList();
            events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return events;
        }

        Domain.Entities.Event IEventRepository.Get(int id)
        {
            var rEvent = _ctx.Events.Include("Host").Include("Manager").Include("Organizer").Where(x => x.EventId == id).FirstOrDefault();
            rEvent.isAvailable = (rEvent.Date > DateTime.Now) ? true : false;

            return rEvent;
        }

        IEnumerable<Domain.Entities.Event> IEventRepository.Find(System.Linq.Expressions.Expression<Func<Domain.Entities.Event, bool>> predicate)
        {
            var events = _ctx.Events.Where(predicate).ToList();
            events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return events;
        }
    }
}

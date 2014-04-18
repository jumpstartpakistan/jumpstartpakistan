using JumpStartPakistan.Domain.Entities;
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


        public IEnumerable<Event> Get()
        {
            var events = _ctx.Events.Include("Host").Include("Manager").Include("Organizer").ToList();
            events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return events;
        }

        public Event Get(int id)
        {
            var rEvent = _ctx.Events.Include("Host").Include("Manager").Include("Organizer").Where(x => x.EventId == id).FirstOrDefault();
            rEvent.isAvailable = (rEvent.Date > DateTime.Now) ? true : false;

            return rEvent;
        }

        public IEnumerable<Event> Find(System.Linq.Expressions.Expression<Func<Domain.Entities.Event, bool>> predicate)
        {
            var events = _ctx.Events.Where(predicate).ToList();
            events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return events;
        }

        public void Add(Event nEvent)
        {
            //bool isDone = false;
            var found = _ctx.Events.Where(x => x.EventId == nEvent.EventId).FirstOrDefault();
            if (found == null)
            {
                found = _ctx.Events.Add(nEvent);

            }
            else
            {
                var entry = _ctx.Entry(found);
                entry.OriginalValues.SetValues(found);
                entry.CurrentValues.SetValues(nEvent);
            }
            
            _ctx.SaveChanges();
            //void isDone;
        }
    }
}

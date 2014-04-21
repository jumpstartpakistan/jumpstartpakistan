using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Data.Repositories
{
    public class EventManagerRepository :IEventManagerRepository
    {
        private readonly JumpStartPakistanDataContext _ctx;

        #region construction
        public EventManagerRepository()
            : this(new JumpStartPakistanDataContext())
        {

        }

        public EventManagerRepository(JumpStartPakistanDataContext ctx)
        {
            _ctx = ctx;
        }
        #endregion


        public IEnumerable<EventManager> Get()
        {
            var managers = _ctx.EventManagers.ToList();
            //events.ForEach(x => x.isAvailable = (x.Date > DateTime.Now) ? true : false);
            return managers;
        }

        public EventManager Get(int id)
        {
            var manager = _ctx.EventManagers.Where(x => x.ManagerId == id).FirstOrDefault();           

            return manager;
        }

        public IEnumerable<EventManager> Find(System.Linq.Expressions.Expression<Func<Domain.Entities.EventManager, bool>> predicate)
        {
            var managers = _ctx.EventManagers.Where(predicate).ToList();            
            return managers;
        }

        public void Add(EventManager nEventManager)
        {
            //bool isDone = false;
            var found = _ctx.EventManagers.Where(x => x.ManagerId == nEventManager.ManagerId).FirstOrDefault();
            if (found == null)
            {
                found = _ctx.EventManagers.Add(nEventManager);

            }
            else
            {
                var entry = _ctx.Entry(found);
                entry.OriginalValues.SetValues(found);
                entry.CurrentValues.SetValues(nEventManager);
            }
            
            _ctx.SaveChanges();
            //void isDone;
        }

        public void Remove(int id)
        {
            //bool isDone = false;
            var found = _ctx.EventManagers.Where(x => x.ManagerId == id).FirstOrDefault();
            if (found != null)
            {
                found = _ctx.EventManagers.Remove(found);

            }            

            _ctx.SaveChanges();
            //void isDone;
        }


    }
}

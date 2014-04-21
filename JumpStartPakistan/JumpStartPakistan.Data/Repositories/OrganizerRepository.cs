using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Data.Repositories
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly JumpStartPakistanDataContext _ctx;

        #region construction
        public OrganizerRepository()
            : this(new JumpStartPakistanDataContext())
        {

        }

        public OrganizerRepository(JumpStartPakistanDataContext ctx)
        {
            _ctx = ctx;
        }
        #endregion


        public IEnumerable<Organizer> Get()
        {
            var organizers = _ctx.Organizers.ToList();

            return organizers;
        }

        public Organizer Get(int id)
        {
            var organizer = _ctx.Organizers.Where(x => x.OrganizerId == id).FirstOrDefault();
            return organizer;
        }

        public IEnumerable<Organizer> Find(System.Linq.Expressions.Expression<Func<Domain.Entities.Organizer, bool>> predicate)
        {
            var organizers = _ctx.Organizers.Where(predicate).ToList();

            return organizers;
        }

        public void Add(Organizer organizer)
        {
            //bool isDone = false;
            var found = _ctx.Organizers.Where(x => x.OrganizerId == organizer.OrganizerId).FirstOrDefault();
            if (found == null)
            {
                found = _ctx.Organizers.Add(organizer);

            }
            else
            {
                var entry = _ctx.Entry(found);
                entry.OriginalValues.SetValues(found);
                entry.CurrentValues.SetValues(organizer);
            }
            
            _ctx.SaveChanges();
            //void isDone;
        }

        public void Remove(int id)
        {
            //bool isDone = false;
            var found = _ctx.Organizers.Where(x => x.OrganizerId == id).FirstOrDefault();
            if (found != null)
            {
                found = _ctx.Organizers.Remove(found);

            }            

            _ctx.SaveChanges();
            //void isDone;
        }


    }
}

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
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepo;

        public OrganizerService()
            : this(new OrganizerRepository())
        {

        }

        public OrganizerService(IOrganizerRepository organizerRepo)
        {
            _organizerRepo = organizerRepo;
        }

        public IEnumerable<Organizer> Get()
        {
            return _organizerRepo.Get();
        }



        public Organizer Get(int id)
        {
            return _organizerRepo.Get(id);
        }

        public bool Add(Organizer organizer)
        {
            bool isDone = false;

            _organizerRepo.Add(organizer);
            isDone = true;

            return isDone;
           
        }

        public bool Remove(int id)
        {
            bool isDone = false;

            _organizerRepo.Remove(id);
            isDone = true;

            return isDone;            
        }
    }
}

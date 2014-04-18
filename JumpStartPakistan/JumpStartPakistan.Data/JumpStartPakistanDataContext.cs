using JumpStartPakistan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStartPakistan.Data
{
    public class JumpStartPakistanDataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventManager> EventManagers { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Event>(new EventsMap());
            modelBuilder.Configurations.Add<Organizer>(new OrganizersMap());
            modelBuilder.Configurations.Add<Host>(new HostsMap());
            modelBuilder.Configurations.Add<EventManager>(new EventManagersMap());

            base.OnModelCreating(modelBuilder);
        }
    }


    #region EFMappings

    public class EventsMap : EntityTypeConfiguration<Event>
    {
        public EventsMap()
        {
            HasKey(p => p.EventId);

            //HasMany(p => p.Orders);
        }
    }

    public class OrganizersMap : EntityTypeConfiguration<Organizer>
    {
        public OrganizersMap()
        {
            HasKey(p => p.OrganizerId);
            //HasMany(p => p.Orders);
        }
    }

    public class HostsMap : EntityTypeConfiguration<Host>
    {
        public HostsMap()
        {
            HasKey(p => p.HostId);
            //HasMany(p => p.Orders);
        }
    }

    public class EventManagersMap : EntityTypeConfiguration<EventManager>
    {
        public EventManagersMap()
        {
            HasKey(p => p.ManagerId);
            //HasMany(p => p.Orders);
        }
    }

    #endregion

}

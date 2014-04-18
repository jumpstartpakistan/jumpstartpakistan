namespace JumpStartPakistan.Data.Migrations
{
    using JumpStartPakistan.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<JumpStartPakistan.Data.JumpStartPakistanDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "JumpStartPakistan.Data.JumpStartPakistanDataContext";
        }

        protected override void Seed(JumpStartPakistan.Data.JumpStartPakistanDataContext context)
        {
            List<Host> hosts = new List<Host> { 
                new Host { Title="seecs"},
                new Host { Title="HEC"},
                new Host {Title="Lums"},
                new Host { Title = "fast"}
            };

            List<Organizer> organizers = new List<Organizer> { 
                new Organizer { Title="Moftak Solutions"},
                new Organizer { Title="Jumpstart Pakistan"},
                new Organizer {Title="Binex"}
                
            };

            List<EventManager> managers = new List<EventManager>{ 
                new EventManager { Name="fakhar abbas", Email="fakhar@jumpstartpakistan.com"},
                new EventManager { Name="najam sikander awan", Email="najam.sikander@moftak.com"}
            };

            List<Event> events = new List<Event> { 
                new Event{ 
                    Date = DateTime.Now.AddDays(3), 
                    Details= "fast lahore best practices", 
                    Host = hosts[3], 
                    Organizer=organizers[1], 
                    isActive=true,
                    isAvailable=true, 
                    Location="lahore", 
                    Summary="jiyeah lahore", 
                    Title="lahore best", 
                    Manager = managers[0],
                    RegisterationLink = string.Empty,
                },
                 new Event{ 
                    Date = DateTime.Now.AddDays(3), 
                    Details= "global startup weekend", 
                    Host = hosts[0], 
                    Organizer=organizers[0], 
                    isActive=true,
                    isAvailable=true, 
                    Location="lahore", 
                    Summary="jiyeah lahore", 
                    Title="islamabad startup weekend", 
                    Manager = managers[1],
                    RegisterationLink = "http://www.google.com"
                }
            };

            context.Hosts.AddOrUpdate(o => o.Title, hosts.ToArray());
            context.Organizers.AddOrUpdate(o => o.Title, organizers.ToArray());
            context.Events.AddOrUpdate(o => o.Title, events.ToArray());
        }
    }
}

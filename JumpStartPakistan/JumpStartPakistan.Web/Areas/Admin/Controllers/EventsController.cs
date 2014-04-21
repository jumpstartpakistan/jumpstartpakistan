using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartPakistan.Web.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {

        private readonly IEventService _eventService;
        private readonly IHostService _hostService;
        private readonly IOrganizerService _organizerService;
        private readonly IEventManagerService _eventManagerService;
        

        public EventsController(): this( new EventService(), new HostService(), new OrganizerService(), new EventManagerService())
        {

        }

        public EventsController(IEventService eventService, IHostService hostService, IOrganizerService organizerService, IEventManagerService eventManagerService)
        {
            _eventService = eventService;
            _hostService = hostService;
            _eventManagerService = eventManagerService;
            _organizerService = organizerService;
        }

       
        
        //
        // GET: /Admin/Events/
        public ActionResult Index(string msg)
        {
            var events = _eventService.Get().OrderByDescending(x=>x.EventId);
            ViewBag.msg = msg;
            ViewData["hosts"] = _hostService.Get();

            
            //ViewBag.hosts = _hostService.Get();
            return View(events);
        }


        public ActionResult Details(int id)
        {
            var rEvent = _eventService.Get(id);
            return View(rEvent);
        }

        public ActionResult Edit(int id)
        {
            var rEvent = _eventService.Get(id);
            
            var hosts = _hostService.Get().ToList();
            hosts.Insert(0, new Host { HostId = 0, Title = "select" });            
            var hostList = from host in hosts select new SelectListItem { Text = host.Title, Value = host.HostId.ToString() };
            ViewBag.hostList = hostList;

            var oraganizers = _organizerService.Get().ToList();
            oraganizers.Insert(0, new Organizer { OrganizerId = 0, Title = "select" });
            var organizerList = from o in oraganizers select new SelectListItem { Text = o.Title, Value = o.OrganizerId.ToString() };
            ViewBag.organizerList = organizerList;

            var managers = _eventManagerService.Get().ToList();
            managers.Insert(0, new EventManager { ManagerId = 0, Name = "select" });
            var managerList = from m in managers select new SelectListItem { Text = m.Name, Value = m.ManagerId.ToString() };
            ViewBag.managerList = managerList;


            return View(rEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event posted)
        {
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(posted);
            }

            //save posted to db
            bool completed = _eventService.Add(posted);
            if (completed)
            {
                return RedirectToAction("details", new  { id = posted.EventId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(posted);
            }
        }

        [HttpPost]
        public ActionResult Create(Event newEvent)
        {
            //var rEvent = _eventService.GetEventById(id);
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(newEvent);
            }
            bool completed = _eventService.Add(newEvent);
            if (completed)
            {
                return RedirectToAction("details", new { id = newEvent.EventId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(newEvent);
            }
           
        }

        public ActionResult Create()
        {
            //var rEvent = _eventService.GetEventById(id);
            return View(new Event());
        }


        public ActionResult Delete(int id)
        {
            //var rEvent = _eventService.GetEventById(id);
            bool isDone = _eventService.Remove(id);
            return RedirectToAction("Index", new { msg = "record deleted successfully." });
        }
	}
}
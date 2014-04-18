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


        public EventsController(): this( new EventService())
        {

        }

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

       
        
        //
        // GET: /Admin/Events/
        public ActionResult Index()
        {
            var events = _eventService.GetEvents().OrderByDescending(x=>x.EventId);
            return View(events);
        }


        public ActionResult Details(int id)
        {
            var rEvent= _eventService.GetEventById(id);
            return View(rEvent);
        }

        public ActionResult Edit(int id)
        {
            var rEvent = _eventService.GetEventById(id);
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
	}
}
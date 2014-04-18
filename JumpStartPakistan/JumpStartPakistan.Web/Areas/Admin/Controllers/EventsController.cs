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
            var events = _eventService.GetEvents();
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

        public ActionResult Create()
        {
            //var rEvent = _eventService.GetEventById(id);
            return View(new Event());
        }
	}
}
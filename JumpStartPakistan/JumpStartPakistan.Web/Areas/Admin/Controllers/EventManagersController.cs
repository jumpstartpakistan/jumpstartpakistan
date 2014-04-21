using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartPakistan.Web.Areas.Admin.Controllers
{
    public class EventManagersController : Controller
    {
        
        private readonly IEventManagerService _eventManagerService;


        public EventManagersController(): this( new EventManagerService())
        {

        }

        public EventManagersController(IEventManagerService eventManagerService)
        {
            _eventManagerService = eventManagerService;
        }

        
        //
        // GET: /Admin/EventManagesr/
        public ActionResult Index(string msg)
        {
            var managers = _eventManagerService.Get().OrderByDescending(x => x.ManagerId);
            ViewBag.msg = msg;
            return View(managers);
        }

        public ActionResult Details(int id)
        {
            var rEvent = _eventManagerService.Get(id);
            return View(rEvent);
        }

        public ActionResult Edit(int id)
        {
            var manager = _eventManagerService.Get(id);
            return View(manager);
        }

        [HttpPost]
        public ActionResult Edit(EventManager posted)
        {
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(posted);
            }

            //save posted to db
            bool completed = _eventManagerService.Add(posted);
            if (completed)
            {
                return RedirectToAction("details", new { id = posted.ManagerId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(posted);
            }
        }

        [HttpPost]
        public ActionResult Create(EventManager eventManager)
        {
            //var rEvent = _eventService.GetEventById(id);
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(eventManager);
            }
            bool completed = _eventManagerService.Add(eventManager);
            if (completed)
            {
                return RedirectToAction("details", new { id = eventManager.ManagerId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(eventManager);
            }

        }

        public ActionResult Create()
        {
            //var rEvent = _eventService.GetEventById(id);
            return View(new EventManager());
        }


        public ActionResult Delete(int id)
        {
            //var rEvent = _eventService.GetEventById(id);
            bool isDone = _eventManagerService.Remove(id);
            return RedirectToAction("Index", new { msg = "record deleted successfully." });
        }

	}
}
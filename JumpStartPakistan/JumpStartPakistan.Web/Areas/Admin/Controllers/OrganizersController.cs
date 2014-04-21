using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartPakistan.Web.Areas.Admin.Controllers
{
    public class OrganizersController : Controller
    {
        
        private readonly IOrganizerService _organizerService;


        public OrganizersController(): this( new OrganizerService())
        {

        }

        public OrganizersController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }


        //
        // GET: /Admin/Events/
        public ActionResult Index(string msg)
        {
            var organizers = _organizerService.Get().OrderByDescending(x => x.OrganizerId);
            ViewBag.msg = msg;
            return View(organizers);
        }


        public ActionResult Details(int id)
        {
            var organizer = _organizerService.Get(id);
            return View(organizer);
        }

        public ActionResult Edit(int id)
        {
            var organizer = _organizerService.Get(id);
            return View(organizer);
        }

        [HttpPost]
        public ActionResult Edit(Organizer posted)
        {
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(posted);
            }

            //save posted to db
            bool completed = _organizerService.Add(posted);
            if (completed)
            {
                return RedirectToAction("details", new { id = posted.OrganizerId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(posted);
            }
        }

        [HttpPost]
        public ActionResult Create(Organizer organizer)
        {
            //var rEvent = _eventService.GetEventById(id);
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(organizer);
            }
            bool completed = _organizerService.Add(organizer);
            if (completed)
            {
                return RedirectToAction("details", new { id = organizer.OrganizerId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(organizer);
            }

        }

        public ActionResult Create()
        {
            //var rEvent = _eventService.GetEventById(id);
            return View(new Organizer());
        }


        public ActionResult Delete(int id)
        {
            //var rEvent = _eventService.GetEventById(id);
            bool isDone = _organizerService.Remove(id);
            return RedirectToAction("Index", new { msg = "record deleted successfully." });
        }
	}
}
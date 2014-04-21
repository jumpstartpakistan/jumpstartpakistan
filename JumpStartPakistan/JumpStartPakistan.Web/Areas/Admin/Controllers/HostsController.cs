using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartPakistan.Web.Areas.Admin.Controllers
{
    public class HostsController : Controller
    {
        
        private readonly IHostService _hostService;


        public HostsController(): this( new HostService())
        {

        }

        public HostsController(IHostService hostService)
        {
            _hostService = hostService;
        }


        //
        // GET: /Admin/Events/
        public ActionResult Index(string msg)
        {
            var hosts = _hostService.Get().OrderByDescending(x => x.HostId);
            ViewBag.msg = msg;
            return View(hosts);
        }


        public ActionResult Details(int id)
        {
            var host = _hostService.Get(id);
            return View(host);
        }

        public ActionResult Edit(int id)
        {
            var host = _hostService.Get(id);
            return View(host);
        }

        [HttpPost]
        public ActionResult Edit(Host posted)
        {
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(posted);
            }

            //save posted to db
            bool completed = _hostService.Add(posted);
            if (completed)
            {
                return RedirectToAction("details", new { id = posted.HostId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(posted);
            }
        }

        [HttpPost]
        public ActionResult Create(Host host)
        {
            //var rEvent = _eventService.GetEventById(id);
            if (!ModelState.IsValid)
            {
                ViewBag["error"] = "validation fails";
                return View(host);
            }
            bool completed = _hostService.Add(host);
            if (completed)
            {
                return RedirectToAction("details", new { id = host.HostId });
            }
            else
            {
                ViewBag["error"] = "can't save record into database";
                return View(host);
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
            bool isDone = _hostService.Remove(id);
            return RedirectToAction("Index", new { msg = "record deleted successfully." });
        }
	}
}
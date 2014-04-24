using JumpStartPakistan.Domain.Entities;
using JumpStartPakistan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JumpStartPakistan.WebApi.Controllers
{
  [RoutePrefix("api/v1/events")]   
    public class EventsController : ApiController
    {
        private readonly IEventService _eventService;

        public EventsController() : this( new EventService())
        {

        }

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Route("")]
        [HttpGet]
        public List<Event> Index() {
            
            var events = _eventService.Get().OrderByDescending(x => x.EventId);
            return events.ToList();
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public Event Get(int id)
        {

            var result = _eventService.Get(id);
            if (result == null)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, Content = new StringContent("event not found") });
            }
            return result;
        }
    }
}

using HouseManagementApp.Core.Contracts;
using HouseManagementApp.Core.Models.Calendar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace HouseManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }


        [HttpGet]
        [Route("getAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await eventService.GetAllEvents());
        }

        [HttpPost]
        [Route("addEvent")]
        public async Task<String> AddEvent([FromBody] EventModel eventObject)
        {

            return await eventService.AddEvent(eventObject);
        }
    }
}

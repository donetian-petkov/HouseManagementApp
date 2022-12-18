using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Models.Calendar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace PersonalManagementApp.API.Controllers
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
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await eventService.GetAll());
        }

        [HttpPost]
        [Route("add")]
        public async Task<String> Add([FromBody] EventModel eventObject)
        {

            return await eventService.Add(eventObject);
        }
        
        [HttpDelete]
        [Route("deleteById")]
        public async Task DeleteById([FromQuery] string eventId)
        {

            await eventService.DeleteById(eventId);
        }
    }
}

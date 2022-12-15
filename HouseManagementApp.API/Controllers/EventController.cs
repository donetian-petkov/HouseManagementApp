using HouseManagementApp.Core.Contracts;
using HouseManagementApp.Core.Models.Calendar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(IEnumerable<EventModel>))]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await eventService.GetAllEvents());
        }
    }
}

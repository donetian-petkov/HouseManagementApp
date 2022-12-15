using HouseManagementApp.Core.Contracts;
using HouseManagementApp.Core.Models.Calendar;
using HouseManagementApp.Infrastructure.Data.Common;
using HouseManagementApp.Infrastructure.Data.Models.Calendar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagementApp.Core.Services
{
    public class EventService : IEventService
    {

        private readonly IRepository repo;

        public EventService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<EventModel>> GetAllEvents()
        {
            return await repo.AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Start = e.Start,
                    End = e.End
                })
                .ToListAsync();


        }
    }
}

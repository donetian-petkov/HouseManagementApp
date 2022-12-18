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

        public async Task<string> Add(EventModel eventModel)
        {
            var eventToCreate = new Event()
            {
                Id = eventModel.id,
                Title = eventModel.title,
                Start = eventModel.start,
                End = eventModel.end
            };
            
            await repo.AddAsync(eventToCreate);
            await repo.SaveChangesAsync();

            return eventToCreate.Id;
        }

        public async Task DeleteById(string eventId)
        {
            
            await repo.DeleteAsync<Event>(eventId);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventModel>> GetAll()
        {
            return await repo.AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    id = e.Id,
                    title = e.Title,
                    start = e.Start,
                    end = e.End
                })
                .ToListAsync();


        }
    }
}

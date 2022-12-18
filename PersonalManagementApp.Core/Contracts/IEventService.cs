using PersonalManagementApp.Core.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Core.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> GetAll();

        Task<String> Add (EventModel eventModel);   
        
        Task DeleteById (string eventId);  
    }
}

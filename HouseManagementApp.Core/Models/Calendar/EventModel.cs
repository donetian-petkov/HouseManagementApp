using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagementApp.Core.Models.Calendar
{
    public class EventModel
    {
        public String id { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; } = null!;

        [Required]
        public DateTime start { get; set; }

        [Required]
        public DateTime end { get; set; }
    }
}

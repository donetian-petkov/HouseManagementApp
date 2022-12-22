using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Core.Models.Notes
{
    public class NoteAddModel
    {
        [StringLength(20)]
        public string title { get; set; }

        [StringLength(500)]
        public string content { get; set; }

        public bool favourited;
    }
}

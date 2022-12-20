using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Core.Models.TodoList
{
    public class TodoModel
    {
        public String id { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; } = null!;

        [Required]
        public bool complete { get; set; }
    }
}

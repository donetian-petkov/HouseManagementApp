using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Infrastructure.Data.Models.TodoList
{
    public class Todo
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        public bool Complete { get; set; }
    }
}

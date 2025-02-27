﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Infrastructure.Data.Models.Calendar
{
    public class Event
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Start { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime End { get; set; }

    }
}

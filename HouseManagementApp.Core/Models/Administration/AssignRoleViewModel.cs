using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagementApp.Core.Models.Administration
{
    public class AssignRoleViewModel
    {
        [Required]
        public IEnumerable<IdentityUser> Users { get; set; } = null!;

        [Required]
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}

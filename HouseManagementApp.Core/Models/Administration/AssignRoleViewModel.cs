using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace HouseManagementApp.Core.Models.Administration
{
    public class AssignRoleViewModel
    {
        public IEnumerable<IdentityUser>? Users { get; set; } 
        
        public IEnumerable<IdentityRole>? Roles { get; set; } 
        
        public string? UserId { get; set; } 
        
        public string? RoleName { get; set; } 
    }
}

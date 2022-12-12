using System.ComponentModel.DataAnnotations;

namespace HouseManagementApp.Core.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}

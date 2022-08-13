using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.UserDTO
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(15, ErrorMessage = "Cant be more than 15")]
        public string UserName { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(15, ErrorMessage = "Cant be more than 15")]
        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}

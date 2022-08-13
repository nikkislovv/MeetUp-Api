using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.UserDTO
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(15, ErrorMessage = "Cant be more than 15")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(15, ErrorMessage = "Cant be more than 15")]
        public string Password { get; set; }
    }
}

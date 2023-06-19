using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UserForRegisterDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [Required(ErrorMessage ="Username is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Password is required")] 
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Roles { get; set; } //burası ICollection türünde idi
    }
}

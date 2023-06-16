using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UserLoginDto
    {
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
    }
}

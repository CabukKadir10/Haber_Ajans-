using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegister);
        Task<AppUser> GetByIdUser(string id);
    }
}

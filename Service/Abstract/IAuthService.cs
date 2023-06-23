using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
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
        //Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        //Task<bool> ValidateUser(string UserName, string Password);
        //Task<string> CreateToken();

        IDataResult<AccessToken> CreateAccessToken(AppUser user, AppRole role /*int newsId*/);
    }
}

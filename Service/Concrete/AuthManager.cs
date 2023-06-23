using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Jwt;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(AppUser user, AppRole role /*int newsId*/)
        {
           // var claims = _userService.GetRoles(p=> p.Id == role.Id);
            var accessToken = _tokenHelper.CreateToken(user, role);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}

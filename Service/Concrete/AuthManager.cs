using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegister)
        {
            var user = _mapper.Map<AppUser>(userForRegister);

            var result = await _userManager.CreateAsync(user, userForRegister.PasswordHash);

            //if(result.Succeeded)
            //{
            //    await _userManager.AddToRolesAsync(user, userForRegister.Roles);
            //}

            return result;
        }

        public async Task<AppUser> GetByIdUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return result;
        }

       
    }
}

using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost("Createuser")]
        public async Task<IActionResult> CreateUser(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                var success = _mapper.Map<AppUserRegisterDto>(result); 
                if (result.Succeeded)
                {
                    return Ok(success);
                }
            }
            return BadRequest();
        }

        [HttpGet("UserDetail")]
        public async Task<IActionResult> UserDetail(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //[HttpPost("ChangePassword")]
        //public async Task<IActionResult> ChangePasswordUser()
        //{

        //}
    }
}

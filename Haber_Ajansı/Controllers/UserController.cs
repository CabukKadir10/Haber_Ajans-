using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Abstract;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(IServiceManager serviceManager, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegister)
        {
            AppRole role = new AppRole();
            role.Name = userForRegister.Roles;

            if (role.Name.Equals("Admin"))
            {
                return BadRequest("Admin Olarak Kayıt Oluşturamazsın");
            }
            
            var user = _mapper.Map<AppUser>(userForRegister);

            if(!(_userManager.Users.Any(u => u.PhoneNumber == userForRegister.PhoneNumber)))
            {
                var result = await _userManager.CreateAsync(user, userForRegister.PasswordHash);
                if (result.Succeeded)
                {
                    var deneme3 = await _userManager.AddToRoleAsync(user, userForRegister.Roles);
                    return Ok(result);
                } 
                else
                    return BadRequest();
            }
            return BadRequest();

        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(error: "Kullanıcı Bulunamadı");
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto /*string phoneNumber, string password, string userName, AppRoleDto role*//*, int newsId*/)
        {
            
            var roles =  _mapper.Map<AppRole>(userLoginDto);
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);//ilk false web sitesinde görünsün mü görünmesin mi ayarlamasını yapıyor. ikinci false ise 5ten fazla yanlış girilmesi ihtimalinde kullanıcıyı blokluyor.


                if (result.Succeeded && user.Roles.Equals(roles.Name))
                {
                    var token = _serviceManager.AuthService.CreateAccessToken(user, roles);
                    return Ok(token);
                }

                return BadRequest(error: "telefon veya şifre hatalı");
            }

            return BadRequest(error: "kayıt bulunamadı");
        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await _userManager.FindByNameAsync(resetPasswordDto.UserName);

            if(result != null)
            {
                var removePassword = await _userManager.RemovePasswordAsync(result);
                var newPassword = await _userManager.AddPasswordAsync(result, resetPasswordDto.Password);

                if (removePassword.Succeeded && newPassword.Succeeded)
                    return Ok("Şifre başarıyla değiştirildi");

                return BadRequest(error: "Şifre değiştirme başarısız oldu.");
            }

            return BadRequest(error: "Kullanıcı bulunamadı");
        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByNameAsync(changePasswordDto.UserName);
            if(user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);

                if (result.Succeeded)
                    return Ok("Şifre değişimi başarılı");
            }

            return BadRequest(error: "Hatalı işlem");
        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByNameAsync(updateUserDto.UserName);
            if(user != null)
            {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return Ok("Kullanıcı Başarıyla Güncellendi");

                return BadRequest(error: "Güncelleme Yapılamadı");
            }

            return BadRequest(error: "Kullanıcı Bulunamadı");
        }
    }
}

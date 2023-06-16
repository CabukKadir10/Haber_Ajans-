using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IServiceManager serviceManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegister)
        {

            var user = _mapper.Map<AppUser>(userForRegister);

            if( !(_userManager.Users.Any(u => u.PhoneNumber == userForRegister.PhoneNumber)))
            {
                var result = await _signInManager.UserManager.CreateAsync(user, userForRegister.PasswordHash);
                if (result.Succeeded)
                    return Ok(result);
                else
                    return BadRequest();
            }

            return BadRequest();

        }

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
        public async Task<IActionResult> UserLogin(string phoneNumber, string password, string userName)
        {
          

            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);//ilk false web sitesinde görünsün mü görünmesin mi ayarlamasını yapıyor. ikinci false ise 5ten fazla yanlış girilmesi ihtimalinde kullanıcıyı blokluyor.
                if (result.Succeeded)
                    return Ok("giriş başarılı");

                return BadRequest(error: "telefon veya şifre hatalı");
            }

            return BadRequest(error: "kayıt bulunamadı");
        }

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

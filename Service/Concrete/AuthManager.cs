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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthManager(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

     
        public async Task<AppUser> GetByIdUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return result;
        }

        //public async Task<SignInResult> Login(UserLoginDto userLoginDto)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.PasswordHash, false, false); //şimdi ilk false bizim tarayıcıda şifremizin kayıtlı kalmasını istiyor mu diye sordu bende gizli kalsın dedim. ikinci false degeri ise kullanıcı 5 defa şifresini yanliş girse onu nlokluyor ben bunuda false yaptım yani özelliği eklemedim.
        //    //if (result.Succeeded)
        //    //{
        //    //    var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
        //    //    if(user.EmailConfirmed == true) //burada kullanıcı kayıt yapmış ama maili onaylamamişsa giriş yapmasına izin vermiyoruz.
        //    //    {
        //    //        //burayada gerekli hata mesajı falan girilebilir.
        //    //    }
        //    //}

        //    return result;
        //}
       
    }
}

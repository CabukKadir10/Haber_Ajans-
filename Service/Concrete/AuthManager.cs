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
        //private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly RoleManager<AppRole> _roleManager;
        //private readonly IMapper _mapper;
        //private readonly IConfiguration _configuration;

        //private AppUser _user;

        //public AuthManager(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        //{
        //    _userManager = userManager;
        //    _mapper = mapper;
        //    _signInManager = signInManager;
        //    _roleManager = roleManager;
        //    _configuration = configuration;
        //}

        //public async Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        //{
        //    var user = _mapper.Map<AppUser>(userForRegisterDto);

        //    var result = await _userManager
        //        .CreateAsync(user, userForRegisterDto.PasswordHash);

        //    if (result.Succeeded)
        //        await _userManager.AddToRoleAsync(user, userForRegisterDto.Roles);
        //    return result;
        //}

        //public async Task<bool> ValidateUser(string UserName, string Password)
        //{
        //    _user = await _userManager.FindByNameAsync(UserName);
        //    var result = (_user != null && await _userManager.CheckPasswordAsync(_user, Password));

        //    return result;
        //}

        //public async Task<string> CreateToken()
        //{
        //    var signinCredentials = GetSignInCredentials(); //kimlik bilgilerini alıyoruz.
        //    var claims = await GetClaims(); //rolleri alıyoruz
        //    var tokenOptions = GenerateTokenOptions(signinCredentials, claims); //token oluşturma için özellikleri aldık

        //    return new JwtSecurityTokenHandler().WriteToken(tokenOptions); //burda ise artık tokenı oluşturuyoruz.
        //}

        //private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        //{
        //    var jwtSettings = _configuration.GetSection("JwtSettings");

        //    var tokenOptions = new JwtSecurityToken(
        //            issuer: jwtSettings["validIssuer"],
        //            audience: jwtSettings["validAudience"],
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
        //            signingCredentials: signinCredentials);

        //    return tokenOptions;
        //}

        //private async Task<List<Claim>> GetClaims()
        //{
        //    var claims = new List<Claim>();
        //    //{
        //    //    new Claim(ClaimTypes.Name , _user.UserName)
        //    //};

        //    var roles = await _userManager.GetRolesAsync(_user);

        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    return claims;
        //}

        //private SigningCredentials GetSignInCredentials()
        //{
        //    var jwtSettings = _configuration.GetSection("JwtSettings");
        //    var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
        //    var secret = new SymmetricSecurityKey(key);

        //    return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        //}

        //private SigningCredentials GetSignInCredentials()
        //{
        //    var jwtSettings = _configuration.GetSection("JwtSettings");
        //    var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
        //    var secret = new SymmetricSecurityKey(key);
        //    return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        //}

        //private async Task<List<Claim>> GetClaims()
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, _user.UserName)
        //    };

        //    var roles = await _userManager
        //        .GetRolesAsync(_user);

        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }
        //    return claims;
        //}

        //private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials,
        //    List<Claim> claims)
        //{
        //    var jwtSettings = _configuration.GetSection("JwtSettings");

        //    var tokenOptions = new JwtSecurityToken(
        //            issuer: jwtSettings["validIssuer"],
        //            audience: jwtSettings["validAudience"],
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
        //            signingCredentials: signinCredentials);

        //    return tokenOptions;
        //}

        //private string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}

        //public async Task<AppUser> GetByIdUser(string id)
        //{
        //    var result = await _userManager.FindByIdAsync(id);
        //    return result;
        //}

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

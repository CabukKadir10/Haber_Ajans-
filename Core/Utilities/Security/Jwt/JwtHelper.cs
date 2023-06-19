using Core.Extensions;
using Core.Utilities.Security.Encription;
using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(AppUser appUser/*, AppRole appRole*/, int newsId)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signinCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, appUser, signinCredentials/*, appRole*/, newsId);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
                NewsId = newsId
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser appUser, SigningCredentials signinCredentials, /*AppRole appRole*/ int newsId)
        {
            var jwt = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _accessTokenExpiration,
                    notBefore: DateTime.Now,
                   // claims: SetClaims(appUser, appRole, newsId),
                    signingCredentials: signinCredentials
                    );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(AppUser appUser, AppRole appRole, int newsId)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentityfier(appUser.Id.ToString());
            claims.AddEmail(appUser.Email);
            claims.AddName($"{appUser.Name}");
            claims.AddRoles(appRole.Name);
            claims.AddNews(newsId.ToString());

            return claims;
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        //public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var jwtSetting = configuration.GetSection("JwtSettings");
        //    var secretKey = jwtSetting["secretKey"];

        //    services.AddAuthentication(opt =>
        //    {
        //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(options =>
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = jwtSetting["validIssuer"],
        //            ValidAudience = jwtSetting["validAudience"],
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        //        }
        //    );
        //}
    }
}

using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service.Abstract;
using Service.Concrete;
using System.Text;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IEfNewsDal, EfNewsDal>();
            services.AddScoped<IEfSetting, EfSetting>();
            services.AddScoped<IEfUserDal, EfUserDal>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IMailSenderService, MailSenderManager>();
            services.AddScoped<INewsService, NewsManager>();
            services.AddScoped<ISettingService, SettingManager>();
            services.AddScoped<IUserService, UserrManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();
        }




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

using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Encription;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Abstract;
using Service.Concrete;
using System.Configuration;
using WebApi.Extensions;
//using Service.DependencyResolvers.AutoFac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddDefaultTokenProviders();
builder.Services.AddAuthentication();

//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); //AutoFac ayarlamalar� yap�ld�.
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusinessModule()));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IEfNewsDal, EfNewsDal>();
builder.Services.AddScoped<IEfUserDal, EfUserDal>();
builder.Services.AddScoped<IEfSetting, EfSetting>();
builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddScoped<IMailSenderService, MailSenderManager>();
builder.Services.AddScoped<INewsService, NewsManager>();
builder.Services.AddScoped<ISettingService, SettingManager>();
builder.Services.AddScoped<IUserService, UserrManager>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();
//builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432; Database=eReconciliationDb; UserName=postgres ; Password=1234;"));
//builder.Services.AddIdentity<AppUser, AppRole>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //burada postgre de hata verdi�i i�in ekledim
//AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

IConfiguration configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
       builder => builder.WithOrigins("https://localhost:7200"));
});

var tokenOptions = configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.Jwt.TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

//IConfiguration configuration = builder.Configuration;

//builder.Services.AddControllers();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowOrigin",
//        builder => builder.WithOrigins("https://localhost:7096"));
//});
//#region cors a��klamas�
////CORS, web taray�c�s�n�n bir kayna��n (�rne�in bir web sitesi) belirli bir kayna�a (�rne�in bir API) eri�mesine izin vermek veya engellemek i�in taray�c� taraf�ndan uygulanan bir g�venlik �nlemidir.
////CORS politikalar�, API'lerin veya sunucular�n kaynaklar�na hangi kaynaklardan eri�ilebilece�ini kontrol etmek i�in kullan�l�r. Bu �ekilde, g�venlik �nlemleri al�n�r ve istemcilerin yetkisiz eri�imlerden kaynaklanan g�venlik a��klar�n� s�m�rmesi engellenir.
//#endregion
//var tokenOptions = configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.Jwt.TokenOptions>(); //getsection appsetting dosyalar�ndaki �zelliklere eri�im sa�lar.

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = false,
//        ValidIssuer = tokenOptions.Issuer,
//        ValidAudience = tokenOptions.Audience,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//    };
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    });
}

app.UseCors(builder => builder.WithOrigins("https://localhost:7200").AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

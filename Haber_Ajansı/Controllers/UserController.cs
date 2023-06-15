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

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegister)
        {
            var result = await _serviceManager.AuthService.RegisterUser(userForRegister);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _serviceManager.AuthService.GetByIdUser(id);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}

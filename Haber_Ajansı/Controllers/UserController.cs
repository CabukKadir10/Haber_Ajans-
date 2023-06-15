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
        private readonly IAuthService _auth;

        public UserController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegister)
        {
            var result = await _auth.RegisterUser(userForRegister);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _auth.GetByIdUser(id);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}

//using Autofac.Core;
//using Entity.Dto;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Service.Abstract;

//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;

//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        //[HttpPost]
//        //public async Task<IActionResult> RegisterUser([FromBody] UserForRegisterDto userForRegisterDto)
//        //{
//        //    var result = await _authService
//        //        .RegisterUser(userForRegisterDto);

//        //    if (!result.Succeeded)
//        //    {
//        //        foreach (var error in result.Errors)
//        //        {
//        //            ModelState.TryAddModelError(error.Code, error.Description);
//        //        }
//        //        return BadRequest(ModelState);
//        //    }

//        //    return StatusCode(201);
//        //}

//        //[HttpPost("login")]
//        //public async Task<IActionResult> Authenticate([FromBody]  user)
//        //{
//        //    if (!await _authService.ValidateUser(user))
//        //        return Unauthorized(); // 401

//        //    var tokenDto = await _authService
//        //        .CreateToken();

//        //    return Ok(tokenDto);
//        //}
//    }
//}

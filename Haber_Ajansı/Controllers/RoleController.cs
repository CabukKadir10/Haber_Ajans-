using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<AppRole>(createRoleDto);
            IdentityResult result = await _roleManager.CreateAsync(role);
            if(result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest("Rol eklenemedi");
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var getRole = await _roleManager.FindByIdAsync(updateRoleDto.Id);
            var role = _mapper.Map<AppRole>(updateRoleDto);
            var result = await _roleManager.UpdateAsync(role);
            if(result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest("Güncelleme Başarısız");
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var getRole = await _roleManager.FindByIdAsync(roleId);
            IdentityResult result = await _roleManager.DeleteAsync(getRole);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest("Silme İşlemi Başarısız");
        }
    }
}

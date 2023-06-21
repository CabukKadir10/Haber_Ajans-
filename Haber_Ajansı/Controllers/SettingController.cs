using DataAccess.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;
        private readonly IRepositoryManager _repositoryManager;

        public SettingController(ISettingService settingService, IRepositoryManager repositoryManager)
        {
            _settingService = settingService;
            _repositoryManager = repositoryManager;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("BakımdaMı")]
        public IActionResult Get(int settingId)
        {
            if(!(_settingService.IsMaintenance(settingId)))
            {
                return Ok("site bakımda değil");
            }

            return BadRequest(error: "site bakımda");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("BakımaAl")]
        public IActionResult Post(int settingId)
        {
            _settingService.OnMaintenance(settingId);
            _repositoryManager.Save();
            return Ok("site bakıma alındı");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("BakımıBitir")]
        public IActionResult Delete(int settingId)
        {
            _settingService.OfMaintenance(settingId);
            _repositoryManager.Save();
            return Ok("site bakımı Bitirildi");
        }
    }
}

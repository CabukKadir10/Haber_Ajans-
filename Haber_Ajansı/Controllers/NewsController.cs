using AutoMapper;
using DataAccess.Migrations;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public NewsController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("CreateNews")]
        public IActionResult CreateNews([FromForm] CreateNewsDto createNewsDto/*, IFormFile file*/)
        {
           // var deneme = GetByteArrayFromImage(createNewsDto.Image);

            var extension = Path.GetExtension(createNewsDto.Image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = $"{Directory.GetCurrentDirectory()}/Content/{newImageName}";
            var stream = new FileStream(location, FileMode.Create);
            createNewsDto.Image.CopyTo(stream);
   
            var news = _mapper.Map<News>(createNewsDto);
            news.ImageUrl = newImageName;
            var result = _serviceManager.NewsService.CreateNews(news);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetNewsById")]
        public IActionResult GetNewsById(int id)
        {
            var result = _serviceManager.NewsService.GetNews(p => p.Id==id);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}

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


        //[HttpGet]
        //public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var filePath = Path.GetTempFileName();

        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    // Process uploaded files
        //    // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size });
        //}

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
            var deneme = GetByteArrayFromImage(createNewsDto.Image);

            var extension = Path.GetExtension(createNewsDto.Image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = $"{Directory.GetCurrentDirectory()}/Content/{newImageName}";
            var stream = new FileStream(location, FileMode.Create);
            createNewsDto.Image.CopyTo(stream);
            // createNewsDto.Image = newImageName;

            
            var news = _mapper.Map<News>(createNewsDto);
            news.ImageUrl = deneme;
            var result = _serviceManager.NewsService.CreateNews(news);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();

            //if (file != null)
            //{
            //    var extension = Path.GetExtension(file.FileName);
            //    var newImageName = Guid.NewGuid() + extension;
            //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/", newImageName);
            //    var stream = new FileStream(location, FileMode.Create);
            //    file.CopyTo(stream);
            //    createNewsDto.ImageUrl = newImageName;
            //}

            //if (file.Length > 0)
            //{
            //    var fileName = Guid.NewGuid().ToString() + ".xlsx"; //dosya adı belirledik
            //    var filePath = $"{Directory.GetCurrentDirectory()}/Content/{fileName}"; //dosya yolunu aldık
            //    using (FileStream stream = System.IO.File.Create(filePath))
            //    {
            //        file.CopyTo(stream);
            //        stream.Flush();
            //    }

            //    var deneme = _serviceManager.NewsService.AddImage(filePath);
            //    createNewsDto.ImageUrl = deneme;
            //}
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

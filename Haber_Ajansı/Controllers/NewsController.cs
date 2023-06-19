using AutoMapper;
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


        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("CreateNews")]
        public IActionResult CreateNews(CreateNewsDto createNewsDto)
        {

            var news = _mapper.Map<News>(createNewsDto);
            var result = _serviceManager.NewsService.CreateNews(news);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();

            //if(ImageUrl != null)
            //{
            //    var extension = Path.GetExtension(ImageUrl.FileName);
            //    var newImageName = Guid.NewGuid() + extension;
            //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/", newImageName);
            //    var stream = new FileStream(location, FileMode.Create);
            //    ImageUrl.CopyTo(stream);
            //    createNewsDto.ImageUrl = newImageName;
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

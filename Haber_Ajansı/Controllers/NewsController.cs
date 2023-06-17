using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        }

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

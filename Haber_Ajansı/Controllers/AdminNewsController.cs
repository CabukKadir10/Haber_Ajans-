using AutoMapper;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Service.Abstract;
using Service.Constans;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminNewsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public AdminNewsController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet("TümHaberler")]
        public IActionResult GetListNews()
        {
            var result = _serviceManager.NewsService.GetAllNews();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetUserDetail")]
        public async Task<IActionResult> GetUserDetail(string id)
        {
            var result = await _serviceManager.AuthService.GetByIdUser(id);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetAllIsDeleted")]
        public IActionResult GetAllIsDeleted()
        {
            var result = _serviceManager.NewsService.GetNews(a => a.IsDeleted == true);
            if(result != null )
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("OnayBekleyen")]
        public IActionResult ApprovalNews()
        {
            var result = _serviceManager.NewsService.GetListNews(o => o.Status == "False");
            if( result != null )
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("Onaylanan")]
        public IActionResult Approve()
        {
            var result = _serviceManager.NewsService.GetListNews(o => o.Status == "True");
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("BuHaftaEklenenler")]
        public IActionResult AddedThisWeek()
        {
            var startDate = DateTime.Now.AddDays(-7);
            var result = _serviceManager.NewsService.GetListNews(o => o.Date >= startDate);
            if(result !=null )
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("HardDeleteNews")]
        public IActionResult HardDeleteNews(int id)
        {
            var dec = _serviceManager.NewsService.Any(o => o.Id == id);
            if(dec == true)
            {
                var getNews = _serviceManager.NewsService.GetNews(ı => ı.Id == id);
               var news = _mapper.Map<News>(getNews);
                var result = _serviceManager.NewsService.DeleteNews(news);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("NewsDelete")]
        public  IActionResult NewsDelete(int id)
        {
             var getNews = _serviceManager.NewsService.GetNews(ı => ı.Id == id);
             //var news = _mapper.Map<News>(getNews);
             if(getNews.Data.IsDeleted == false)
             {
                 getNews.Data.IsDeleted = true;
                 var result = _serviceManager.NewsService.UpdateNews(getNews.Data);
                 return Ok(result);
             }
             else
             {
                 return BadRequest();
             }
        }

        [HttpGet("NewsUpdate")]
        public IActionResult NewsUpdate(int id)
        {
            var getNews = _serviceManager.NewsService.GetNews(ı => ı.Id == id);
            //var news = _mapper.Map<News>(getNews);
            if (getNews.Data.IsDeleted == true)
            {
                getNews.Data.IsDeleted = false;
                var result = _serviceManager.NewsService.UpdateNews(getNews.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        
    }
}

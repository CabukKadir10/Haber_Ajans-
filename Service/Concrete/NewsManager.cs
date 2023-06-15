using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class NewsManager : INewsService
    {
        private readonly IRepositoryManager _repositoryManager;

        public NewsManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IResult CreateNews(News news)
        {
            _repositoryManager.EfNewsDal.CreateNews(news);
            _repositoryManager.Save();
            return new SuccessResult();
        }

        public IResult DeleteNews(News news)
        {
            _repositoryManager.EfNewsDal.DeleteNews(news);
            _repositoryManager.Save();
            return new SuccessResult();
        }

        public IDataResult<List<News>> GetAllNews()
        {
            return new SuccessDataResult<List<News>>(_repositoryManager.EfNewsDal.GetAllNews());
        }

        public IDataResult<News> GetNews(int id)
        {
           return new SuccessDataResult<News>(_repositoryManager.EfNewsDal.GetNews(id));
        }

        public IResult UpdateNews(News news)
        {
             _repositoryManager.EfNewsDal.UpdateNews(news);
            _repositoryManager.Save();
            return new SuccessResult();
        }
    }
}

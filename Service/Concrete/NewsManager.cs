using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto;
using Service.Abstract;
using Service.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IDataResult<List<News>> GetListNews(Expression<Func<News, bool>> filter =null) //bu sorgu ile bize list getirir.
        {
            return new SuccessDataResult<List<News>>(_repositoryManager.EfNewsDal.GetListNews(filter));
        }

        public IDataResult<List<News>> GetAllNews() //bu sorgusuz tüm haberleri getirir
        {
            return new SuccessDataResult<List<News>>(_repositoryManager.EfNewsDal.GetAllNews());
        }

        public IDataResult<News> GetNews(Expression<Func<News, bool>> filter)
        {
           return new SuccessDataResult<News>(_repositoryManager.EfNewsDal.GetNews(filter));
        }

        public IResult UpdateNews(News news)
        {
             _repositoryManager.EfNewsDal.UpdateNews(news);
            _repositoryManager.Save();
            return new SuccessResult();
        }

        public bool Any(Expression<Func<News, bool>> filter)
        {
            return _repositoryManager.EfNewsDal.Any(filter);
        }

     
    }
}

using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface INewsService
    {
        IResult CreateNews(News news);
        IResult DeleteNews(News news);
        IResult UpdateNews(News news);
        IDataResult<News> GetNews(Expression<Func<News, bool>> filter);
        IDataResult<List<News>> GetListNews(Expression<Func<News, bool>> filter);
        IDataResult<List<News>> GetAllNews();
        bool Any(Expression<Func<News, bool>> filter);

        IResult AddImage(string filePath);
    }
}

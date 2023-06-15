using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface INewsService
    {
        IResult CreateNews(News news);
        IResult DeleteNews(News news);
        IResult UpdateNews(News news);
        IDataResult<News> GetNews(int id);
        IDataResult<List<News>> GetAllNews();
    }
}

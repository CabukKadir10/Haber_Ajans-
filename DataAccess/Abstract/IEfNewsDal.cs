using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEfNewsDal
    {
        void CreateNews(News news);
        void DeleteNews(News news);
        void UpdateNews(News news);
        News GetNews(Expression<Func<News, bool>> filter);
        List<News> GetListNews(Expression<Func<News, bool>> filter = null);
        List<News> GetAllNews();
        bool Any(Expression<Func<News, bool>> filter);
    }
}

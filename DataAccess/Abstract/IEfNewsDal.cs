using Entity.Concrete;
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
        News GetNews(int id);
        List<News> GetAllNews();
    }
}

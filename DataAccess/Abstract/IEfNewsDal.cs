using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEfNewsDal
    {
        void Create(News news);
        void Delete(News news);
        void Update(News news);
        News GetNews(int id);
        List<News> GetAllNews();
    }
}

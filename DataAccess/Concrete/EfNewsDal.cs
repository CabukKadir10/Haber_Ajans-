using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfNewsDal : RepositoryBase<News>, IEfNewsDal
    {
        public EfNewsDal(AppDbContext context) : base(context)
        {
        }

        public void CreateNews(News news) => Create(news);

        public void DeleteNews(News news) => Delete(news);


        public List<News> GetAllNews()
        {
            return GetList();
        }

        public News GetNews(int id)
        {
            return Get(b => b.Id == id);
        }

        public void UpdateNews(News news) => Update(news);
    }
}

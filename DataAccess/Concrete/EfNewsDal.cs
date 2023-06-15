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

        public bool Any(Expression<Func<News, bool>> filter)
        {
            var result = Anyy(filter);
            return result;
        }

        public void CreateNews(News news) => Create(news);

        public void DeleteNews(News news) => Delete(news);


        public List<News> GetListNews(Expression<Func<News, bool>> filter)
        {
            var result = GetList(filter);
            return result;
        }

        public List<News> GetAllNews()
        {
            var result = GetList();
            return result;
        }

        public News GetNews(Expression<Func<News, bool>> filter)
        {
            var result = Get(filter);
            return result;
        }

        public void UpdateNews(News news) => Update(news);
    }
}

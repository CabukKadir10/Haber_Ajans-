using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfNewsDalll : IEfNewsDal
    {
        public void Create(News news)
        {
            throw new NotImplementedException();
        }

        public void Delete(News news)
        {
            throw new NotImplementedException();
        }

        public List<News> GetAllNews()
        {
            throw new NotImplementedException();
        }

        public News GetNews(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(News news)
        {
            throw new NotImplementedException();
        }
    }
}

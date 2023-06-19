using Entity.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class RepositoryBase<T> : IRepository<T>
        where T : class, IEntity, new()
        
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
           _context.Set<T>().Add(entity);
        }

        public bool Anyy(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Any(filter);
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Count(filter);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().SingleOrDefault(filter);
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                    ? _context.Set<T>().ToList()
                    : _context.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

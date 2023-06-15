using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetList(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);//get fonksiyonunda özellikle birşey istendiği için filter null işaretlenmedi.
        bool Any(Expression<Func<T, bool>> filter);
        int Count(Expression<Func<T, bool>> filter);
    }
}

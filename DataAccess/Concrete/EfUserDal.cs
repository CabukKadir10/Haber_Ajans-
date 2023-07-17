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
    public class EfUserDal : RepositoryBase<AppRole, AppDbContext>, IEfUserDal
    {
       

        //public AppRole GetRoles(Expression<Func<AppRole, bool>> filter)
        //{
        //    var result = Get(filter);
        //    return result;
        //}
    }
}

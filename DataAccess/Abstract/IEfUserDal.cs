using Core.DataAccess;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEfUserDal : IRepository<AppRole>
    {
        //AppRole GetRoles(Expression<Func<AppRole, bool>> filter);
    }
}

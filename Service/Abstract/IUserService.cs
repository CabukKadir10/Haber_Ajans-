using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IUserService
    {
        IDataResult<AppRole> GetRoles(Expression<Func<AppRole, bool>> filter);
    }
}

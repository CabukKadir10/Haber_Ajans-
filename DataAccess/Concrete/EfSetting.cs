using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfSetting : RepositoryBase<Setting>, IEfSetting
    {
        public EfSetting(AppDbContext context) : base(context)
        {
        }

        public Setting Gett(Expression<Func<Setting, bool>> filter)
        {
            var result = Get(filter);
            return result;
        }
    }
}

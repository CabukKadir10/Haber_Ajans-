using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IEfNewsDal _efNewsDal;
        private readonly IEfSetting _efSetting;
        private readonly IEfUserDal _efUserDal;
        public RepositoryManager(AppDbContext context, IEfNewsDal efNewsDal, IEfSetting efSetting, IEfUserDal efUserDal)
        {
            _context = context;
            _efNewsDal = efNewsDal;
            _efSetting = efSetting;
            _efUserDal = efUserDal;
        }
        public IEfNewsDal EfNewsDal => _efNewsDal;

        public IEfSetting EfSetting => _efSetting;

        public IEfUserDal EfUserDal => _efUserDal;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

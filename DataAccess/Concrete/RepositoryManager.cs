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

        public RepositoryManager(AppDbContext context, IEfNewsDal efNewsDal)
        {
            _context = context;
            _efNewsDal = efNewsDal;
        }

        public IEfNewsDal EfNewsDal => _efNewsDal;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

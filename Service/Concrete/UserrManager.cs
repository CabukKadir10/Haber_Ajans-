﻿using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class UserrManager : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserrManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IDataResult<AppRole> GetRoles(Expression<Func<AppRole, bool>> filter)
        {
            return new SuccessDataResult<AppRole>(_repositoryManager.EfUserDal.GetRoles(filter));
        }
    }
}

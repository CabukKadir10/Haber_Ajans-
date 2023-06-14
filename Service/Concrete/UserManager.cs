//using Core.DataAccess;
//using Core.Utilities.Results.Abstract;
//using Core.Utilities.Results.Concrete;
//using DataAccess.Abstract;
//using Entity.Concrete;
//using Entity.Dto;
//using Service.Abstract;
//using Service.Constans;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service.Concrete
//{
//    public class UserManager : IUserService
//    {
//        #region Dependency Injection
//        private readonly IRepository _userDal;

//        public UserManager(IEfUserDal userDal)
//        {
//            _userDal = userDal;
//        }
//        #endregion

//        public IResult Add(AppUser user)
//        {
//            _userDal.Add(user);
//            return new SuccessResult(Messages.addedUser);
//        }

//        public IResult Delete(AppUser user)
//        {
//            _userDal.Delete(user);
//            return new SuccessResult(Messages.deletedUser);
//        }

//        public IDataResult<AppUser> GetById(int id)
//        {
//            return new SuccessDataResult<AppUser>(_userDal.Get(p => p.Id == id));
//        }

//        public IDataResult<List<AppUser>> GetList()
//        {
//            return new SuccessDataResult<List<AppUser>>(_userDal.GetList());
//        }

//        public IResult Update(AppUser user)
//        {
//            _userDal.Update(user);
//            return new SuccessResult(Messages.updatedUser);
//        }
//    }
//}

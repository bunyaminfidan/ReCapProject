using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{

    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        // [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.GetAllUserListed);
        }

        public IDataResult<List<User>> GetByUserId(int userId)
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == userId), Messages.GetByUserIdListed);

        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
    }
}

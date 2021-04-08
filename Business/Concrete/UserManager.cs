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
using Core.Utilitis.Business;

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

        public IDataResult<User> GetById(int userId)
        {

            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.GetByUserIdListed);

        }


        public IResult Update(User user)
        {



            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }


        //public IResult UpdateInfo(User user)
        //{
        //    var userToUpdate = GetById(user.Id).Data;
        //    userToUpdate.FirstName = user.FirstName;
        //    userToUpdate.LastName = user.LastName;
        //    userToUpdate.Email = user.Email;
        //    userToUpdate.FindeksScore = user.FindeksScore;
        //    Update(userToUpdate);
        //    return new SuccessResult(Messages.UserUpdated);
        //}



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

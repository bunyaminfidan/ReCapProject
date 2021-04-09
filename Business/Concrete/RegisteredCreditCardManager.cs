using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RegisteredCreditCardManager : IRegisteredCreditCardService
    {

        IRegisteredCreditCardDal _registeredCreditCardDal;

        public RegisteredCreditCardManager(IRegisteredCreditCardDal registeredCreditCardDal)
        {
            _registeredCreditCardDal = registeredCreditCardDal;

        }

        [ValidationAspect(typeof(RegisteredCreditCardValidator))]
        public IResult Add(RegisteredCreditCard registeredCreditCard)
        {
            _registeredCreditCardDal.Add(registeredCreditCard);

            return new SuccessResult(Messages.RegisteredCreditCardAdded);
        }

        public IResult Delete(RegisteredCreditCard registeredCreditCard)
        {
            _registeredCreditCardDal.Delete(registeredCreditCard);

            return new SuccessResult(Messages.RegisteredCreditCardDeleted);
        }

        public IDataResult<List<RegisteredCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<RegisteredCreditCard>>(_registeredCreditCardDal.GetAll(), Messages.GetAllRegisteredCreditCard);
        }

        public IDataResult<List<RegisteredCreditCard>> GetByRegisteredCreditCardId(int id)
        {
            return new SuccessDataResult<List<RegisteredCreditCard>>(_registeredCreditCardDal.GetAll(r => r.Id == id), Messages.GetByRegisteredCreditCard);
        }

        public IDataResult<List<RegisteredCreditCard>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<RegisteredCreditCard>>(_registeredCreditCardDal.GetAll(r => r.UserId == id), Messages.GetByUserIdRegisteredCreditCard);

        }

        public IResult isRegisteredCreditCard(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardDal.Get(
                r => r.NameOnTheCard == registeredCreditCard.NameOnTheCard &&
                r.Number == registeredCreditCard.Number &&
                r.Cvv == registeredCreditCard.Cvv &&
                r.UserId == registeredCreditCard.UserId &&
                r.IsActive == true);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RegisteredCreditCardValidator))]
        public IResult Update(RegisteredCreditCard registeredCreditCard)
        {
            _registeredCreditCardDal.Update(registeredCreditCard);

            return new SuccessResult(Messages.RegisteredCreditCardUpdated);
        }
    }
}

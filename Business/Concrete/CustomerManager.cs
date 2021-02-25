using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _costumerDal;

        public CustomerManager(ICustomerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer costumer)
        {
            _costumerDal.Add(costumer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer costumer)
        {
            _costumerDal.Delete(costumer);
            return new SuccessResult(Messages.CustomerDeleted);

        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(), Messages.GetAllCustomerListed);
        }

        public IDataResult<List<Customer>> GetByCustomerId(int costumerId)
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(c => c.UserId == costumerId), Messages.GetByCustomerIdListed);
        }

        public IResult Update(Customer costumer)
        {
            _costumerDal.Update(costumer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

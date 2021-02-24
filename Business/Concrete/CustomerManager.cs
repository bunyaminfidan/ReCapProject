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
            return new SuccessResult(Messages.CostumerAdded);
        }

        public IResult Delete(Customer costumer)
        {
            _costumerDal.Delete(costumer);
            return new SuccessResult(Messages.CostumerDeleted);

        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(), Messages.GetAllCostumerListed);
        }

        public IDataResult<List<Customer>> GetByCostumerId(int costumerId)
        {
            return new SuccessDataResult<List<Customer>>(_costumerDal.GetAll(c => c.Id == costumerId), Messages.GetByCostumerIdListed);
        }

        public IResult Update(Customer costumer)
        {
            _costumerDal.Update(costumer);
            return new SuccessResult(Messages.CostumerUpdated);
        }
    }
}

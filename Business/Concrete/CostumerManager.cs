using Business.Abstract;
using Core.Utilitis;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CostumerManager : ICostumerService
    {
        ICostumerDal _costumerDal;

        public CostumerManager(ICostumerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }

        public IResult Add(Costumer costumer)
        {
            _costumerDal.Add(costumer);
            return new SuccessResult(Messages.CostumerAdded);
        }

        public IResult Delete(Costumer costumer)
        {
            _costumerDal.Delete(costumer);
            return new SuccessResult(Messages.CostumerDeleted);

        }

        public IDataResult<List<Costumer>> GetAll()
        {
            return new SuccessDataResult<List<Costumer>>(_costumerDal.GetAll(), Messages.GetAllCostumerListed);
        }

        public IDataResult<List<Costumer>> GetByCostumerId(int costumerId)
        {
            return new SuccessDataResult<List<Costumer>>(_costumerDal.GetAll(c => c.Id == costumerId), Messages.GetByCostumerIdListed);
        }

        public IResult Update(Costumer costumer)
        {
            _costumerDal.Update(costumer);
            return new SuccessResult(Messages.CostumerUpdated);
        }
    }
}

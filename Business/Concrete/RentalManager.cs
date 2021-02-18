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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetAllRentalListed);
        }

        public IDataResult<List<Rental>> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId), Messages.GetByRentalIdListed);

        }

        public IResult Update(Rental rental)
        {

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

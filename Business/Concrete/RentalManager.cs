using Business.Abstract;
using Core.Utilitis;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using Entities.DTOs;
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

            var isCarDelivered = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);


            if (isCarDelivered.Count > 0)
            {
                return new ErrorResult(Messages.RentalCancelled);
            }

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
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetRentalDetail);
        }

        public IDataResult<List<RentalDetailDto>> GetByIdRentalDetail(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetByIdRentealDetail(id), Messages.GetByIdRentalDetail);

        }

        public IDataResult<List<Rental>> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId), Messages.GetByIdRentalDetail);

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.GetRentalDetail);
        }



        public IResult Update(Rental rental)
        {

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

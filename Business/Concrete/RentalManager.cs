using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilitis.Results;
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

                                                                   //--POST--

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var isCarDelivered = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (isCarDelivered.Count > 0)
            {
                return new ErrorResult(Messages.CarNotReceived);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Rental rental)
        {

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

                                                                        //--GET--

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetRentalDetail);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.GetRentalDetail);
        }

        public IDataResult<List<RentalDetailDto>> GetByCarIdRentalDetail(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId), Messages.GetByCarIdRentalDetail);

        }

        public IDataResult<List<RentalDetailDto>> GetByCustomerIdRentalDetail(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CustomerId == customerId),Messages.GetByCustomerIdRentalDetail);
        }

        public IDataResult<List<Rental>> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId), Messages.GetByRentalId);
        }

        public IDataResult<List<RentalDetailDto>> GetByRentDateRentalDetail(DateTime rentDate)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.RentDate == rentDate),Messages.GetByRentDateRentalDetail);

        }

        public IDataResult<List<RentalDetailDto>> GetByReturnDateRentalDetail(DateTime returnDate)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == returnDate),Messages.GetByReturnDateRentalDetail);

        }

    }
}

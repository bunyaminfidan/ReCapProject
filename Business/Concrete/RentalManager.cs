using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Validation;
using Core.Utilitis.Business;
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
        IUserDal _userDal;
        ICarDal _carDal;
        ICustomerDal _customerDal;




        public RentalManager(IRentalDal rentalDal, IUserDal userDal, ICarDal carDal, ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _userDal = userDal;
            _carDal = carDal;
            _customerDal = customerDal;

        }

        //--POST--

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(FindeksInsufficient(rental), IsCarDelivered(rental));
            if (result != null)
            {
                return result;
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
            IResult result = BusinessRules.Run(FindeksInsufficient(rental), IsCarDelivered(rental));
            if (result != null)
            {
                return result;
            }
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
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CustomerId == customerId), Messages.GetByCustomerIdRentalDetail);
        }

        public IDataResult<List<Rental>> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId), Messages.GetByRentalId);
        }

        public IDataResult<List<RentalDetailDto>> GetByRentDateRentalDetail(DateTime rentDate)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.RentDate == rentDate), Messages.GetByRentDateRentalDetail);

        }

        public IDataResult<List<RentalDetailDto>> GetByReturnDateRentalDetail(DateTime returnDate)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == returnDate), Messages.GetByReturnDateRentalDetail);

        }

        private IResult FindeksInsufficient(Rental rental)
        {

            var customer = _customerDal.Get(c => c.Id == rental.CustomerId);
            var car = _carDal.Get(c => c.Id == rental.CarId);
            var user = _userDal.Get(u => u.Id == customer.UserId);

            var userFindeksPoint = user.FindeksPoint;
            var carFindeksPoint = car.FindeksPoint;


            if (userFindeksPoint < carFindeksPoint)
            {
                return new ErrorResult(Messages.RentalFindeksInsufficient);

            }
            return new SuccessResult();

        }

        private IResult IsCarDelivered(Rental rental)
        {
            var isCarDelivered = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (isCarDelivered.Count > 0)
            {
                return new ErrorResult(Messages.CarNotReceived);
            }
            return new SuccessResult();
        }

    }
}

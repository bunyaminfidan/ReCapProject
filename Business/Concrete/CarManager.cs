using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using DataAccess.Constans;
using Business.ValidationRules.FluentValidation;
using FluentValidation;
using Core.Utilitis.Results;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching.Microsoft;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        // [PerformanceAspect(1)]
        [SecuredOperation("car.add,admin")]
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")] //içerisinde bu parametre olan tüm cacheleri siler
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            //  throw new Exception("hata testi");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandIdCarDetails(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.CarByBrandIdDetailListed);
        }

        public IDataResult<List<CarDetailDto>> GetByColorIdCarDetails(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.CarByColorIdDetailListed);
        }

        public IDataResult<List<CarDetailDto>> GetByIdCarDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId), Messages.CarByIdDetailListed);
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Car>> GetByIdCar(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == carId), Messages.GetCarByIdListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.GetCarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarIdDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId), Messages.GetCarDetailsListed);
       
        }

        public IDataResult<List<Car>> GetByBrandIdCar(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId), Messages.GetCarsByBrandIdListed);
        }

        public IDataResult<List<Car>> GetByColorIdCar(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.GetCarsByColorIdListed);

        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

            return new ErrorResult(Messages.CarPriceInValid);
        }
    }
}

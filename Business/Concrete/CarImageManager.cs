using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilitis.Business;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(FileHelper.Delete(carImage.ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }



        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.GetAllCarImage);

        }
        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == id), Messages.GetByIdCarImage);
        }

        public IDataResult<List<CarImage>> GetByCarIdImage(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckisCarImageNull(carId));
        }

        private List<CarImage> CheckisCarImageNull(int carId)
        {
            var defaultImagesPath = FileHelper.DefaultPath();
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = defaultImagesPath, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Update(file, carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var checkCarImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (checkCarImageCount >= 5)
            {
                return new ErrorResult(Messages.FailedCarImageLimiit);
            }
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }
    }
}

using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilitis.Business;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IResult Add(CarImage carImage, string extension)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var savedCarImage = CreatedCarFeatureAndImagesPath(carImage, extension, "").Data;
            _carImageDal.Add(savedCarImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {

            string sourcePath = carImage.ImagePath;
            try
            {
                if (carImage.Id != null && carImage.Id > 0)
                {
                    File.Delete(sourcePath);
                    _carImageDal.Delete(carImage);
                    return new SuccessResult(Messages.CarImageDeleted);
                }
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
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
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.GetByCarIdCarImage);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, string deleteOldImage, string extension)
        {
            var updatedCarImage = CreatedCarFeatureAndImagesPath(carImage, extension, deleteOldImage).Data;
            _carImageDal.Update(updatedCarImage);
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

        private IDataResult<CarImage> CreatedCarFeatureAndImagesPath(CarImage carImage, string extension, string deleteOldImage)
        {


            string savedPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            var newUniqueFilename = Guid.NewGuid().ToString("N") + "_"
                + DateTime.Now.Year + "_"
                + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Hour + "_"
                + DateTime.Now.Minute + "_"
                + DateTime.Now.Second + "_"
                + DateTime.Now.Millisecond + "_"
                + extension;

            string sourcePath = Path.Combine(carImage.ImagePath);
            string savedFullPath = $@"{savedPath}\{newUniqueFilename}";
            try
            {
                File.Move(sourcePath, savedPath + @"\" + newUniqueFilename);
                if (carImage.Id != null && carImage.Id > 0)
                {
                    File.Delete(deleteOldImage);
                }

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<CarImage>(exception.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = savedFullPath, Date = DateTime.Now },
                Messages.CarImageAdded);
        }


    }
}

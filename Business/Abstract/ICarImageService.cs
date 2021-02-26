using Core.Utilitis.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(int id);
        IDataResult<List<CarImage>> GetByCarIdImage(int carId);
        IResult Add(CarImage carImage, string extension);
        IResult Update(CarImage carImage, string deleteOldImage, string extension);
        IResult Delete(CarImage carImage);
    }
}

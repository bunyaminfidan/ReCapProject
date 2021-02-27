using Core.Utilitis.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetById(int Id);
        IDataResult<List<CarImage>> GetByCarIdImage(int carImageId);

        IResult Add(IFormFile file, CarImage carImage  );
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}

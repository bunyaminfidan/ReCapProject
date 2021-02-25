using Business.Abstract;
using Core.Utilitis.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        public IResult Add(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByCarImageId(int carImageId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}

using Core.Utilitis.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByIdCar(int carId); 
        IDataResult<List<Car>> GetByBrandIdCar(int brandId);
        IDataResult<List<Car>> GetByColorIdCar(int colorId);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<List<CarDetailDto>> GetByIdCarDetails(int carId);
        IDataResult<List<CarDetailDto>> GetByColorIdCarDetails(int colorId );
        IDataResult<List<CarDetailDto>> GetByBrandIdCarDetails(int brandId );





    }
}

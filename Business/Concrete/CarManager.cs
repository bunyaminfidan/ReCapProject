using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            
            if (car.Description.Length>2 && car.DailyPrice>0 )
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Hata");
                Console.WriteLine("Araba günlük kiralama fiyatı '0' dan büyük olmalıdır. ");
                Console.WriteLine("Araba açıklaması minumum 3 karakter olmalıdır. ");
            }

           
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
          return  _carDal.GetAll();
        }

        public List<Car> GetCarById(int carId)
        {
            return _carDal.GetAll(c => c.Id==carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(b => b.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);

        }

        public void Update(Car car)
        {
            if ( car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Hata");
                Console.WriteLine("Araba günlük kiralama fiyatı '0' dan büyük olmalıdır. ");
            }


            
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
  public  class InMemoryCarDal : ICarDal
    {
        List<Car> _car;


        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1, BrandId=2, ColorId=3,DailyPrice=100 , ModelYear=1994, Description="Güzel Araç 1 "},
            new Car { Id = 2, BrandId = 2, ColorId = 4, DailyPrice = 200, ModelYear = 1998, Description = "Güzel Araç 2" },
            new Car { Id = 3, BrandId = 3, ColorId = 7, DailyPrice = 300, ModelYear = 2010, Description = "Güzel Araç 3" },
            new Car { Id = 4, BrandId = 10, ColorId = 9, DailyPrice = 400, ModelYear = 2015, Description = "Güzel Araç 5" },
            new Car { Id = 5, BrandId = 8, ColorId = 5, DailyPrice = 500, ModelYear = 2020, Description = "Güzel Araç 5" },
        };

        }


        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car _carToDelete = null;

            _carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);

            _car.Remove(_carToDelete);

        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetCarById(int carId)
        {
            return _car.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car _carToUpdate = null;

            _carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);

            _carToUpdate.Id = car.Id;
            _carToUpdate.BrandId = car.BrandId;
            _carToUpdate.ColorId = car.ColorId;
            _carToUpdate.DailyPrice = car.DailyPrice;
            _carToUpdate.ModelYear = car.ModelYear;
            _carToUpdate.Description = car.Description;

        }
    }
}

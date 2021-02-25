
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarProjectDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCarProjectDatabaseContext context = new ReCarProjectDatabaseContext())
            {
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)

                             join color in context.Colors
                             on car.ColorId equals color.Id

                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             select new CarDetailDto { BrandName = brand.BrandName, CarName = car.Description, ColorName = color.ColorName, DailyPrice = car.DailyPrice };
                return result.ToList();
            }
        }
    }
}

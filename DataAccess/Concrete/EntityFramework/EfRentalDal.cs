using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;


using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarProjectDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetByIdRentealDetail(int rentalId)
        {
            using (ReCarProjectDatabaseContext context = new ReCarProjectDatabaseContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id

                             join costumer in context.Costumers
                             on rental.CostomerId equals costumer.Id

                             join user in context.Users
                             on costumer.Id equals user.Id

                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join color in context.Colors
                             on car.ColorId equals color.Id

                             where rental.Id == rentalId

                             select new RentalDetailDto
                             {
                                 id = rental.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CompanyName = costumer.CompanyName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Email = user.Email,
                                 FirsName = user.FirstName,
                                 LastName = user.LastName,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();


            }
        }

        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCarProjectDatabaseContext context = new ReCarProjectDatabaseContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id

                             join costumer in context.Costumers
                             on rental.CostomerId equals costumer.Id

                             join user in context.Users
                             on costumer.Id equals user.Id

                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join color in context.Colors
                             on car.ColorId equals color.Id

                             select new RentalDetailDto
                             {
                                 id = rental.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CompanyName = costumer.CompanyName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Email = user.Email,
                                 FirsName = user.FirstName,
                                 LastName = user.LastName,
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();


            }
        }
    }
}

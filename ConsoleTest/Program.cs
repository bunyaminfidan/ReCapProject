using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /// CarGetAllTest();
            //CarAddTest();
            // CarUpdateTest();
            // CarDeleteTest();
            // GetCarByIdTest();
            // GetByIdCarDetailsTest();

            // CarDeleteTest();



            // ColorAddTest();
            // ColorUpdateTest();


            //BrandAddTest();
            //BrandUpdateTest();

            //  CostumerAddTested();

            //UserAddTested();

            // RentalAddTest();
            //RentalGetAll();

        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.CarId + rental.RentDate.ToString());
            }
            Console.WriteLine(result.Message);
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, RentDate = DateTime.Now.Date, ReturnDate = (DateTime.Now.Date) });
            Console.WriteLine(result.Message);
        }

        private static void UserAddTested()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "Bünyamin", LastName = "FİDAN", Email = "deneme@deneme", Password = "12345" });
            Console.WriteLine(result.Message);
        }

        private static void CostumerAddTested()
        {
            CostumerManager costumerManager = new CostumerManager(new EfCostumerDal());
            costumerManager.Add(new Costumer { Id = 1, CompanyName = "Fidan Şirket" });
            costumerManager.Add(new Costumer { Id = 2, CompanyName = "Yılmaz Şirket" });
            costumerManager.Add(new Costumer { Id = 3, CompanyName = "Burcu Şirket" });
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 3 });
            Console.WriteLine("Araba Silindi.");
        }

        private static void GetByIdCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByIdCarDetails(1003);
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "--//-- " + car.ColorName + "--//-- " + car.DailyPrice + " --//--" + car.CarName);

                }
            }
            Console.WriteLine(result.Message);
        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarById(1003);
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            Console.WriteLine(result.Message);

        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 1003, ColorId = 28, ModelYear = 2020, BrandId = 9, DailyPrice = 5000, Description = "Buketin Arabası" });

        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 28, ColorName = "Gri" });

        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 9, BrandName = "Citroren Jumper" });

        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 28, BrandName = "Mercedes Benz" });

        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Id = 4, ColorName = "Siyah" });

        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car { ColorId = 255, ModelYear = 2020, BrandId = 9, DailyPrice = 400, Description = "Buketin Arabası" });
            Console.WriteLine(result.Message);
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "--//-- " + car.ColorName + "--//-- " + car.DailyPrice + " --//--" + car.CarName);
                }
            }
            Console.WriteLine(result.Message);

        }
    }
}

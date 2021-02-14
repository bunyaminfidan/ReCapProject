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
            // CarGetAllTest();
            //  CarAddTest();
            // CarUpdateTest();
            //CarDeleteTest();
            //  GetCarByIdTest();
            //GetByIdCarDetailsTest();

            //CarDeleteTest();



            //  ColorAddTest();
            // ColorUpdateTest();


            // BrandAddTest();
            //BrandUpdateTest();


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

            foreach (var car in carManager.GetByIdCarDetails(1003))
            {
                Console.WriteLine(car.BrandName + "--//-- " + car.ColorName + "--//-- " + car.DailyPrice + " --//--" + car.CarName);

            }
        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarById(1003))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 1003, ColorId = 28, ModelYear = 2020, BrandId = 9, DailyPrice = 5000, Description = "Buketin Arabası" });
            Console.WriteLine("Araba Güncellendi");
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 28, ColorName = "Gri" });
            Console.WriteLine("Renk Güncellendi");
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 9, BrandName = "Citroren Jumper" });
            Console.WriteLine("Güncellendi");
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 28, BrandName = "Mercedes Benz" });
            Console.WriteLine("Eklendi");
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Id = 9, ColorName = "Beyaz" });
            Console.WriteLine("Eklendi");
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { ColorId = 28, ModelYear = 2020, BrandId = 9, DailyPrice = 400, Description = "Buketin Arabası" });
            Console.WriteLine("Eklendi");
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "--//-- "+ car.ColorName + "--//-- "+ car.DailyPrice+ " --//--"+ car.CarName );
            }
        }
    }
}

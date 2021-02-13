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
            CarManager carManager = new CarManager(new EfCarDal());





            Console.WriteLine("*********BAŞLADI***************");

            carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 100, Description = "Araba 4", ModelYear = 2021 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }



            Console.WriteLine("***************BİTTİ*******************");


        }
    }
}

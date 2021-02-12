using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetCarById(5))
            {
                Console.WriteLine(car.Description );
            }


        }
    }
}

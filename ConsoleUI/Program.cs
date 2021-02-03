﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.Description);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine("---------------------");   
            }
            
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


                Console.WriteLine("Lütfen Yeni Araç Girişi İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
                Console.Write("Araç Marka Id:");
                int brandId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Araç Renk Id:");
                int colorId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Araç Model Yılı:");
                int modelYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Araç Günlük Kira Bedeli:");
                decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Araç Açıklaması:");
                string description = Console.ReadLine();
                Console.Clear();
                carManager.Add(new Car { BrandId = brandId, ColorId = colorId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description });
            
                


        }
    }
}

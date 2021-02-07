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
                int BrandId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Araç Renk Id:");
                int ColorId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Araç Model Yılı:");
                int ModelYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Araç Günlük Kira Bedeli:");
                decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Araç Açıklaması:");
                string Description = Console.ReadLine();
                Console.Clear();
                carManager.Add(new Car { BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });

            

        }
    }
}

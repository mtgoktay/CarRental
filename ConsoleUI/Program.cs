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

            bool islem = true;

            while (islem)
            {
                Console.WriteLine("----------Rent A Car----------" +
                        "\n 1.Araba Ekleme\n" +
                        "\n 2.Araba Güncelleme\n" +
                        "\n 3.Araba Silme\n" +
                        "\n 4.Arabaların Listelenmesi\n" +
                        "\n 5.Detaylı Listelenme\n" +
                        "\n 6.Arabaların Id'sine Göre Listelenmesi\n" +
                        "\n 7.Marka Id'sine Göre Listenlenmesi\n" +
                        "\n 8.Renk Id'sine Göre Listelenmesi\n" +
                        "\n 9.Islem\n\n" +
                        "Yukarıdakilerden hangisi işlemi gerçekleştirmek istiyorusunuz?"
                );

                int sayi = Convert.ToInt32(Console.ReadLine());
                switch (sayi)
                {
                    case 1:

                        //Console.WriteLine("Color Listesi");
                        //GetAllColor(colorManager);

                        //Console.WriteLine("Brand Listesi");
                        //GetAllBrand(brandManager);

                        Console.WriteLine("Car Name:");
                        string carNameAdd = Console.ReadLine();

                        Console.WriteLine("Brand Id:");
                        int brandIdAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id:");
                        int colorIdAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Model Year:");
                        string modelYearAdd = Console.ReadLine();

                        Console.WriteLine("Daily Price:");
                        decimal dailyPriceAdd = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Description:");
                        string descriptionAdd = Console.ReadLine();

                        Car carAdd = new Car
                        {

                            CarName = carNameAdd,
                            BrandId = brandIdAdd,
                            ColorId = colorIdAdd,
                            ModelYear = modelYearAdd,
                            DailyPrice = dailyPriceAdd,
                            Description = descriptionAdd
                        };
                        var result = carManager.Add(carAdd);
                        if (result.Success ==true)
                        {
                            carManager.Add(carAdd);
                        }
                        else
                        {
                            Console.WriteLine(result.Message);
                        }
                            
                            islem = false;
                            break;
                        
                    case 2:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Car Id:");
                        int carIdUpdate = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WriteLine("Car Name:");
                        string carNameUpdate = Console.ReadLine();

                        Console.WriteLine("Color Id:");
                        int colorIdUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Brand Id:");
                        int brandIdUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Model Year:");
                        string modelYearUpdate = Console.ReadLine();

                        Console.WriteLine("Daily Price:");
                        decimal dailyPriceUpdate = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Description:");
                        string descriptionUpdate = Console.ReadLine();
                        Car carUpdate = new Car
                        {
                            Id = carIdUpdate,
                            CarName=carNameUpdate,
                            ColorId = colorIdUpdate,
                            BrandId = brandIdUpdate,
                            ModelYear = modelYearUpdate,
                            DailyPrice = dailyPriceUpdate,
                            Description = descriptionUpdate
                        };
                        carManager.Update(carUpdate);
                        break;

                    case 3:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Hangi Id'ye sahip arabayı silmek istersin");
                        int carIdDelete = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(carManager.GetById(carIdDelete).Data);
                        break;

                    case 4:
                        Console.WriteLine("Arabaların Listelenmesi: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\t Description");
                        GetAllCarDetails(carManager);
                        break;

                    case 5:
                        Console.WriteLine("Arabaların Listelenmesi: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\t Description");
                        GetAllCarDetails(carManager);
                        islem = false;
                        break;
                       
                    case 6:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Görmek istediğiniz Id numarasını giriniz? ");
                        int carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n Id'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year \tDaily Price\tDescription");
                        Car carById = carManager.GetById(carId).Data;
                        Console.WriteLine($"{carById.Id}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
                        break;
                    case 7:
                        GetAllBrand(brandManager);
                        Console.WriteLine("Hangi markaya sahip arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
                        int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nBrand Id'si {brandIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
                        foreach (var car in carManager.GetCarsByBrandId(brandIdForCarList).Data)
                        {
                            Console.WriteLine($"{car.Id}\t{car.CarName}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;
                    case 8:
                        GetAllColor(colorManager);
                        Console.WriteLine("Hangi renge sahip arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
                        int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nColor Id'si {colorIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
                        foreach (var car in carManager.GetCarsByColorId(colorIdForCarList).Data)
                        {
                            Console.WriteLine($"{car.Id}\t{car.CarName}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 9:
                        islem = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;

                }
            }

        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarAllDetails();
            if (result.Success==true)
            {
                
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.Id}\t{car.CarName}\t{car.ColorName}\t{car.BrandName}\t{car.ModelYear}\t{car.DailyPrice}\t{car.Description}");

                }
            }
            else 
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId}\t{color.ColorName}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.Id}\t{car.CarName}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                }

            }
            


            //CarManager carManager = new CarManager(new EfCarDal());
            ////BrandManager brandManager = new BrandManager(new EfBrandDal());
            ////ColorManager colorManager = new ColorManager(new EfColorDal());

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.Write(car.BrandId+ "-"+ car.BrandName+"--"+ car.ColorName);
            //    Console.Write("***");
            //    Console.Write("Araç Detayları: "+car.Description);
            //    Console.WriteLine();
            //}            



            //Console.WriteLine("Lütfen Yeni Araç Girişi İçin Aşağıda ki Bilgileri Sırası İle Eksiksiz Giriniz.");
            //Console.Write("Araç Marka Id:");
            //int BrandId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Araç Renk Id:");
            //int ColorId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Araç Model Yılı:");
            //int ModelYear = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Araç Günlük Kira Bedeli:");
            //decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            //Console.Write("Araç Açıklaması:");
            //string Description = Console.ReadLine();
            //Console.Clear();
            //carManager.Add(new Car { BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });



        }
    }
}

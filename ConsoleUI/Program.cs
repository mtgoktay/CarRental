using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Linq;
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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

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
                        "\n 9.Kullanıcı Ekle\n" +
                        "\n 10.Kullanıcı Sil\n" +
                        "\n 11.Kullanıcı Güncelle\n" +
                        "\n 12.Kullanıcı Listesi\n" +
                        "\n 13.Müşteri Ekle\n" +
                        "\n 14.Müşteri Sil\n" +
                        "\n 15.Müşteri Güncelle\n" +
                        "\n 16.Müşteri Listesi\n" +
                        "\n 17.Araç Kirala\n" +
                        "\n 18.Kiralanmış Araç Bilgilerini Güncelle\n" +
                        "\n 19.Kiralanmış Araç Listesi\n" +
                        "\n 20.Islem\n\n" +
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
                        int dailyPriceAdd = Convert.ToInt32(Console.ReadLine());

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
                        if (result.Success == true)
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
                        int dailyPriceUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Description:");
                        string descriptionUpdate = Console.ReadLine();
                        Car carUpdate = new Car
                        {
                            Id = carIdUpdate,
                            CarName = carNameUpdate,
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
                        string ad, soyad, email, password;
                        Console.WriteLine("Kullanıcı adı giriniz.");
                        ad = Console.ReadLine();
                        Console.WriteLine("Kullanıcı soyadı giriniz.");
                        soyad = Console.ReadLine();
                        Console.WriteLine("Email giriniz.");
                        email = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz.");
                        password = Console.ReadLine();
                        User user = new User { FirstName = ad, LastName = soyad, Email = email, Password = password };
                        userManager.Add(user);
                        Console.WriteLine("Kullanıcı başarıyla eklendi.");
                        break;
                    case 10:

                        int id = 0;
                        Console.WriteLine("Silmek istediğiniz kullanıcının Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        User user2 = new User { Id = id };
                        userManager.Delete(user2);
                        Console.WriteLine("Kullanıcı başarıyla silindi.");
                        break;
                    case 11:
                        int id2 = 0;
                        string ad2, soyad2, email2, password2;
                        Console.WriteLine("Güncellemek istediğiniz kullanıcının Id değerini giriniz.");
                        id2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kullanıcı adı giriniz.");
                        ad2 = Console.ReadLine();
                        Console.WriteLine("Kullanıcı soyadı giriniz.");
                        soyad2 = Console.ReadLine();
                        Console.WriteLine("Email giriniz.");
                        email2 = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz.");
                        password2 = Console.ReadLine();
                        User user3 = new User { FirstName = ad2, LastName = soyad2, Email = email2, Password = password2 };
                        userManager.Update(user3);
                        Console.WriteLine("Kullanıcı bilgileri başarıyla güncellenmiştir.");
                        break;
                    case 12:

                        foreach (var user4 in userManager.GetAll().Data)
                        {
                            Console.WriteLine("Id:" + user4.Id + "/" + user4.FirstName + "/" + user4.LastName + "/" + user4.Email + "/" + user4.Password);
                            Console.WriteLine("---------------------------------------------");
                        }
                        break;
                    case 13:

                        int userId;
                        string companyName;
                        Console.WriteLine("Eklemek istediğiniz müşterinin kullanıcı Id değerini giriniz.");
                        userId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Şirket adını giriniz.");
                        companyName = Console.ReadLine();
                        Customer customer = new Customer { UserId = userId, CompanyName = companyName };
                        customerManager.Add(customer);
                        Console.WriteLine("Müşteri başarıyla eklendi.");
                        break;
                    case 14:

                        int id3 = 0;
                        Console.WriteLine("Silmek istediğiniz müşterinin Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Customer customer2 = new Customer { Id = id3 };
                        customerManager.Delete(customer2);
                        Console.WriteLine("Müşteri başarıyla silindi.");
                        break;
                    case 15:
                        int userId2, id4;
                        string companyName2;
                        Console.WriteLine("Güncellemek istediğiniz müşterinin Id değerini giriniz.");
                        id4 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncellemek istediğiniz müşterinin kullanıcı Id değerini giriniz.");
                        userId2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Şirket adını giriniz.");
                        companyName2 = Console.ReadLine();
                        Customer customer3 = new Customer { Id = id4, UserId = userId2, CompanyName = companyName2 };
                        customerManager.Update(customer3);
                        Console.WriteLine("Müşteri bilgileri başarıyla güncellendi.");
                        break;
                    case 16:
                        foreach (var customer4 in customerManager.GetCustomerDetails().Data)
                        {
                            Console.WriteLine("Id:" + customer4.Id + "/" + customer4.FirstName + "/" + customer4.LastName + "/" + customer4.Email + "/" + customer4.Password + "/" + customer4.CompanyName);
                            Console.WriteLine("---------------------------------------------");
                        }
                        break;
                    case 17:
                        DateTime rentDate, returnDate;
                        int carId2 = 0, customerId = 0;
                        Console.WriteLine("Kiralamak istediğiniz aracın Id değerini giriniz.");
                        carId2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kiralamak istediğiniz müşterinin Id değerini giriniz.");
                        customerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Başlangıç tarihini giriniz.");
                        rentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Bitiş tarihini giriniz.");
                        returnDate = DateTime.Parse(Console.ReadLine());
                        Rental rental = new Rental { CarId = carId2, CustomerId = customerId, RentDate = rentDate, ReturnDate = returnDate };
                        var result2 = rentalManager.Add(rental);
                        if (result2.Success)
                        {
                            rentalManager.Add(rental);

                        }
                        break;

                    case 18:
                        DateTime rentDate2, returnDate2;
                        int carId3 = 0, customerId2 = 0;
                        Console.WriteLine("Güncellemek istediğiniz aracın Id değerini giriniz.");
                        carId3 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncelemek istediğiniz müşterinin Id değerini giriniz.");
                        customerId2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Başlangıç tarihini giriniz.");
                        rentDate2 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Bitiş tarihini giriniz.");
                        returnDate2 = DateTime.Parse(Console.ReadLine());
                        Rental rental2 = new Rental { CarId = carId3, CustomerId = customerId2, RentDate = rentDate2, ReturnDate = returnDate2 };
                        var result3 = rentalManager.Update(rental2);
                        if (result3.Success)
                        {
                            rentalManager.Update(rental2);

                        }
                        break;
                    case 19:
                        Console.WriteLine("**************Kiralanmış Araç Listesi**************");
                        foreach (var rentalDto in rentalManager.GetRentalDetails().Data)
                        {
                            Console.WriteLine("Id:" + rentalDto.Id + "/" + rentalDto.FirstName + "/" + rentalDto.LastName + "/" + rentalDto.RentDate + "/" + rentalDto.RentDate + "/" + rentalDto.BrandName + "/" + rentalDto.ColorName + "/" + rentalDto.ModelYear + "/" + rentalDto.DailyPrice + "/" + rentalDto.Description + "/" + rentalDto.CompanyName);
                            Console.WriteLine("---------------------------------------------");
                        }
                        break;
                    case 20:
                        islem = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;

                }
                }
        }

        private static void GetAllCarDetails(CarManager carManager)
            {
                var result = carManager.GetCarAllDetails();
                if (result.Success == true)
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

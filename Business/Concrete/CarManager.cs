using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.BrandId>=1)
            {
                _carDal.Add(car);
                Console.WriteLine("Arac Sisteme basariyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lutfen aracin gunluk kirasini sifirdan buyuk, Marka Id' yi 1'den büyük bir deger giriniz.");
            }
        }

        public void AddCar(CarManager carManager1, CarManager carManager2)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            //İş kodları
            return _carDal.GetAll();
        }

              
        
    }
}

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
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Arac Sisteme basariyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lutfen aracin gunluk kirasini sifirdan buyuk bir deger giriniz.");
            }
        }

        public List<Car> GetAll()
        {
            //İş kodları
            return _carDal.GetAll();
        }

              
        
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ CarId=1, BrandId=1, ColorId="1", ModelYear="2015", DailyPrice=155800, Description="opel Astra", },
                new Car{ CarId=2, BrandId=1, ColorId="1", ModelYear="2016", DailyPrice=165800, Description="opel Vectra", },
                new Car{ CarId=3, BrandId=2, ColorId="3", ModelYear="2018", DailyPrice=175800, Description="bmw 3.20", },
                new Car{ CarId=4, BrandId=2, ColorId="2", ModelYear="2019", DailyPrice=175800, Description="bmw 5.20", },
                new Car{ CarId=5, BrandId=2, ColorId="4", ModelYear="2020", DailyPrice=200000, Description="bmw x5", },
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);

            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _car.Where(p=> p.BrandId == brandId).ToList();
        }

       

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;

        }
    }
}

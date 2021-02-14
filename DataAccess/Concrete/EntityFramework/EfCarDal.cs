using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{    //ORM= Veri tabanındaki tabloyu sanki class mış gibi onunla ilişkilendirip, bundan böyle 
    // bütün opersayonları, sql leri bizim linq  ile yaptığımız bir ortam.
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarAllDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 BrandId = car.BrandId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 Id = car.Id,
                                 CarName=car.CarName


                             };
                return result.ToList();
            }
        }
    }
}

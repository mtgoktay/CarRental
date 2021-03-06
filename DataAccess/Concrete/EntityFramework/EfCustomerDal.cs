﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        public List<CustomerDto> GetCustomerDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.CustomersCars
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDto { Id = c.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, Password = u.Password, CompanyName = c.CompanyName };
                return result.ToList();


            }
        }
    }
}

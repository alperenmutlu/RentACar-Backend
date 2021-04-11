using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarDbContext>, ICustomerDal
    {
        public UserWhoIsCustomerDto GetCustomerIdOfUser(string email)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             where u.Email == email
                             select new UserWhoIsCustomerDto
                             {
                                 userId = u.Id,
                                 email = u.Email,
                                 customerId = c.CustomerId,
                                 FindeksScore = c.FindeksScore,
                                 CompanyName = c.CompanyName
                             };

                return result.SingleOrDefault();
            };
        }

    }
}
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new CustomerDetailDto
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CustomerName = c.CustomerName,
                                 Email = u.Email
                             };
                return result.ToList();
            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users
                             on customer.UserId equals user.UserId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}

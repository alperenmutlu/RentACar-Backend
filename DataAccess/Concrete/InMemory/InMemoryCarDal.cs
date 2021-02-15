using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{CarId =1, BrandId =1,ColorId =1, ModelYear = 2000, DailyPrice = 200000,Description="Mercedes E-200" },
                new Car{CarId =2, BrandId =1,ColorId =2, ModelYear = 2009, DailyPrice = 250000,Description="Mercedes E-250" },
                new Car{CarId =3, BrandId =2,ColorId =2, ModelYear = 2017, DailyPrice = 450000,Description="BMW 420i" },
                new Car{CarId =4, BrandId =3,ColorId =1, ModelYear = 2012, DailyPrice = 50000,Description="Fiat Albea  1.4" },
                new Car{CarId =5, BrandId =1,ColorId =2, ModelYear = 2020, DailyPrice = 1000000,Description="Mercedes S Class" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
           
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}

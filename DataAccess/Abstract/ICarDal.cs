using Core.DataAcces;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface ICarDal:ICarRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}

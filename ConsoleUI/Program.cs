using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());



            bool cikis = true;

            while (cikis)
            {
                Console.WriteLine(
                    "Rent A Car \n-----------------------------------------------" +
                    "\n\n1.Araba Ekleme\n" +
                    "2.Araba Silme\n" +
                    "3.Araba Güncelleme\n" +
                    "4.Arabaların Listelenmesi\n" +
                    "5.Arabaların Marka Id'sine göre Listelenmesi\n" +
                    "6.Arabaların Renk Id'sine göre Listelenmesi\n" +
                    "7.Araba Id'sine göre Listeleme\n" +
                    "8.Arabaların fiyat aralığına göre Listelenmesi\n" +
                    "9.Arabaların model yılına göre Listelenmesi\n" +
                    "10.Arabaları DETAYLARIYLA Listeleme\n"+
                    "11.Çıkış\n" +
                    "Yukarıdakilerden hangi işlemi gerçekleştirmek istiyorsunuz ?"
                    );

                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n---------------------------------------------------------------\n");

                switch (number)
                {
                    case 1:
                        Console.WriteLine("Color Listesi\n\n");
                        foreach (var colors in colorManager.GetAll())
                        {
                            Console.WriteLine(colors.ColorName);
                        }

                        Console.WriteLine("Brand Listesi\n\n");
                        foreach (var brands in brandManager.GetAll())
                        {
                            Console.WriteLine(brands.BrandName);
                        }

                        Console.WriteLine("\nBrand Id: ");
                        int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id :");
                        int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Daily Price: ");
                        decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Description : ");
                        string descriptionForAdd = Console.ReadLine();

                        Console.WriteLine("Model Year: ");
                        int modelYearForAdd = Convert.ToInt32(Console.ReadLine());

                        Car carForAdd = new Car
                        {
                            BrandId = brandIdForAdd,
                            ColorId = colorIdForAdd,
                            DailyPrice = dailyPriceForAdd,
                            Description = descriptionForAdd,
                            ModelYear = modelYearForAdd,

                        };
                        carManager.Add(carForAdd);
                        break;




                    case 2:
                        Console.WriteLine("Hangi Id'ye sahip arabayı silmek istiyorsunuz?");
                        int carIdForDelete = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(carManager.GetById(carIdForDelete));
                        break;

                    case 3:
                        Console.WriteLine("Car Id : ");
                        int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Brand Id : ");
                        int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id  : ");
                        int colorIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Daily Price : ");
                        int dailyPriceForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Description : ");
                        string descriptionForUpdate = Console.ReadLine();

                        Console.WriteLine("Model Year : ");
                        int modelYearForUpdate = Convert.ToInt32(Console.ReadLine());

                        Car carForUpdate = new Car
                        {
                            CarId = carIdForUpdate,
                            BrandId = brandIdForUpdate,
                            ColorId = colorIdForUpdate,
                            DailyPrice = dailyPriceForUpdate,
                            Description = descriptionForUpdate,
                            ModelYear = modelYearForUpdate,
                        };
                        carManager.Update(carForUpdate);
                        break;

                    case 4:
                        Console.WriteLine("Araba Listesi :  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions ");
                        foreach (var car in carManager.GetAll())
                        {
                            Console.WriteLine($"{car.CarId}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Hangi markaya sahip arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
                        int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nBrand Id'si {brandIdForCarList} olan arabalar : \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescription");
                        foreach (var car in carManager.GetAllByBrandId(brandIdForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Hangi renge sahip arabaları görmek istiyorsunuz? Lütfen bir Id numarası yazınız. ");
                        int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nColor Id'si {colorIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescription");
                        foreach (var car in carManager.GetAllByColorId(colorIdForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 7:
                        Console.WriteLine("Hangi arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
                        int carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nId'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
                        Car carById = carManager.GetById(carId);
                        Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
                        break;


                    case 8:
                        decimal min = Convert.ToDecimal(Console.ReadLine());
                        decimal max = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine($"\n\nGünlük fiyat aralığı {min} ile {max} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescription");
                        foreach (var car in carManager.GetByDailyPrice(min, max))
                        {
                            Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 9:
                        Console.WriteLine("Hangi model yılına sahip arabayı görmek istiyorsunuz? Lütfen yıl değeri giriniz.");
                        int modelYearForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nColor Id'si {modelYearForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
                        foreach (var car in carManager.GetByModelYear(modelYearForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 10:
                        Console.WriteLine("Arabaları Detaylıca Listeleme");
                        foreach (var car in carManager.GetCarDetails())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4}", car.CarId, car.BrandName, car.Description, car.ColorName, car.DailyPrice);
                        }
                        break;

                    case 11:
                        cikis = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;
                }



            }




            
            
        }



    }
}


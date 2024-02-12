

//using MotoApp.Entities;
//using MotoApp.Repositories;
//using MotoApp.Repositories.Extentions;

//namespace MotoApp.DataProvider;

//public class CarsProviderBasic : ICarsProvider
//{
//    private readonly IRepository<Car> _carsRepository;
//    public CarsProviderBasic(IRepository<Car> carsRepository)
//    {
//        _carsRepository = carsRepository;
//    }

//    public string AnonymousClass()
//    {
//        throw new NotImplementedException();
//    }

//    public List<Car> FilterCars(decimal minPrice)
//    {
//        var cars = _carsRepository.GetAll();
//        var list = new List<Car>();
//        foreach (var car in cars)
//        {
//            if (car.ListPrice > minPrice)
//            {
//                list.Add(car);
//            }
//        }
//        return list;
//    }

//    public decimal GetMinimumPriceOfAllCars() 
//    {
//        var cars = _carsRepository.GetAll();
//        decimal ret = decimal.MaxValue;
//        foreach (var car in cars)
//        {
//            if (car.ListPrice < ret)
//            {
//                ret = car.ListPrice;
//            }
//        }
//        return ret;
//    }

//    public List<Car> GetSpecificColumns()
//    {
//        throw new NotImplementedException();
//    }

//    public List<string>  GetUniqueCarColors()
//    {
//        var cars = _carsRepository.GetAll();
//        List<string> list = new();
//        foreach (var car in cars)
//        {
//            if (!list.Contains(car.Color))
//            {
//                list.Add(car.Color);
//            }
//        }
//        return list;
//    }
//}

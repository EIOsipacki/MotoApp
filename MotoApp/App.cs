

namespace MotoApp;

using MotoApp.Components.DataProvider;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using System;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(
        IRepository<Employee> employeesRepository, 
        IRepository<Car> carsRepository, 
        ICarsProvider carsProvider)
    {
        _employeesRepository = employeesRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }
    public void Run()
    {
        Console.WriteLine("I'm here in Run() method");

        var employees = new[]
        {
            new Employee { FirstName = "Adam" },
            new Employee { FirstName = "Piotr" },
            new Employee { FirstName = "Zuzia" }
        };

        foreach (var employee in employees)
        {
            _employeesRepository.Add(employee);
        }

        _employeesRepository.Save();

        //reading
        var items = _employeesRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        //cars
        var cars = GenerateSampleCars();
        foreach (var car in cars)
        {
            _carsRepository.Add(car);
        }

        _carsProvider.AnonymousClass();
        //foreach (var car in _carsProvider.FilterCars(1499))
        foreach (var car in _carsProvider.OrderByColorAndNameDesc())
        {
            Console.WriteLine(car);
        }


        Console.WriteLine();
        Console.WriteLine("CetUniqeCarColors");
        foreach (var car in _carsProvider.GetUniqueCarColors())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine();
        Console.WriteLine("GetMinimumPriceOfAllCars");
        Console.WriteLine(_carsProvider.GetMinimumPriceOfAllCars());

        Console.WriteLine();
        Console.WriteLine("CetUniqeCarColors");
        foreach (var car in _carsProvider.GetSpecificColumns())
        {
            Console.WriteLine(car);
        }

        //***************
        //void AnonymousClass();
        Console.WriteLine();
        Console.WriteLine("AnonymousClass");
        _carsProvider.AnonymousClass();

        ////order by
        //List<Car> OrderByName();
        Console.WriteLine();
        Console.WriteLine("OrderByName");
        foreach (var car in _carsProvider.OrderByName())
        {
            Console.WriteLine(car);
        }


        //List<Car> OrderByNameDescending();
        Console.WriteLine();
        Console.WriteLine("OrderByNameDescending");
        foreach (var car in _carsProvider.OrderByNameDescending())
        {
            Console.WriteLine(car);
        }

        //List<Car> OrderByColorAndName();
        Console.WriteLine();
        Console.WriteLine("OrderByColorAndName");
        foreach (var car in _carsProvider.OrderByColorAndName())
        {
            Console.WriteLine(car);
        }

        //List<Car> OrderByColorAndNameDesc();
        Console.WriteLine();
        Console.WriteLine("OrderByColorAndNameDesc");
        foreach (var car in _carsProvider.OrderByColorAndNameDesc())
        {
            Console.WriteLine(car);
        }


        ////where 

        //List<Car> WhereStartsWith(string prefix);
        Console.WriteLine();
        Console.WriteLine("WhereStartsWith");
        foreach (var car in _carsProvider.WhereStartsWith("Ca"))
        {
            Console.WriteLine(car);
        }


        //List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);
        Console.WriteLine();
        Console.WriteLine("WhereStartsWithAndCostIsGreaterThan");
        foreach (var car in _carsProvider.WhereStartsWithAndCostIsGreaterThan("Ca", 1000))
        {
            Console.WriteLine(car);
        }


        //List<Car> WhereColorIs(string color);
        Console.WriteLine();
        Console.WriteLine("WhereColorIs");
        foreach (var car in _carsProvider.WhereColorIs("Black"))
        {
            Console.WriteLine(car);
        }


        ////first, last, single
        //Car FirstByColor(string color);
        Console.WriteLine();
        Console.WriteLine("FirstByColor");
        Console.WriteLine(_carsProvider.FirstByColor("Blue"));

        //Car? FirstOrDefaultByColor(string color);
        Console.WriteLine();
        Console.WriteLine("FirstOrDefaultByColor");
        Console.WriteLine(_carsProvider.FirstByColor("Blue"));


        //Car FirstOrDefaultByColorWithDefault(string color);
        Console.WriteLine();
        Console.WriteLine("FirstOrDefaultByColorWithDefault");
        Console.WriteLine(_carsProvider.FirstOrDefaultByColorWithDefault("Blue"));

        //Car LastByColor(string color);
        Console.WriteLine();
        Console.WriteLine("LastByColor");
        Console.WriteLine(_carsProvider.LastByColor("Black"));

        //Car SingleById(int Id);
        Console.WriteLine();
        Console.WriteLine("SingleById");
        Console.WriteLine(_carsProvider.SingleById(2));

        //Car? SingleOrDefaultById(int id);
        Console.WriteLine();
        Console.WriteLine("SingleOrDefaultById");
        Console.WriteLine(_carsProvider.SingleOrDefaultById(2));


        ////Take
        //List<Car> TakeCars(int howMany);
        Console.WriteLine();
        Console.WriteLine("TakeCars");
        foreach (var car in _carsProvider.TakeCars(3))
        {
            Console.WriteLine(car);
        }

        //List<Car> TakeCars(Range range);
        Console.WriteLine();
        Console.WriteLine("TakeCars");
        foreach (var car in _carsProvider.TakeCars(2..3))
        {
            Console.WriteLine(car);
        }

        //List<Car> TakeCarsWhileNameStartsWith(string prefix);
        Console.WriteLine();
        Console.WriteLine("TakeCarsWhileNameStartsWith");
        foreach (var car in _carsProvider.TakeCarsWhileNameStartsWith("Car"))
        {
            Console.WriteLine(car);
        }

        ////Skip
        //List<Car> SkipCars(int howMany);
        Console.WriteLine();
        Console.WriteLine("SkipCars");
        foreach (var car in _carsProvider.SkipCars(2))
        {
            Console.WriteLine(car);
        }

        //List<Car> SkipCarsWhileNameStartsWith(string prefix);
        Console.WriteLine();
        Console.WriteLine("SkipCarsWhileNameStartsWith");
        foreach (var car in _carsProvider.SkipCarsWhileNameStartsWith("1"))
        {
            Console.WriteLine(car);
        }

        ////Distinct
        //List<string> DistinktAllColors();
        Console.WriteLine();
        Console.WriteLine("DistinktAllColors");
        foreach (var car in _carsProvider.DistinktAllColors())
        {
            Console.WriteLine(car);
        }
        //List<Car> DistinktByColors();
        Console.WriteLine();
        Console.WriteLine("DistinktByColors");
        foreach (var car in _carsProvider.DistinktByColors())
        {
            Console.WriteLine(car);
        }

        ////Chunk
        //List<Car[]> ChunkCars(int size);
        Console.WriteLine();
        Console.WriteLine("ChunkCars");
        foreach (var car in _carsProvider.ChunkCars(2))
        {
            Console.WriteLine("-----------");
            foreach  (var item in car)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------");
        }
        //*****************
    }

    public static List<Car> GenerateSampleCars()
    {
        return new List<Car>
        {
            new Car{
        Id = 101, Name = "Car 1", Color = "Black", StandardCost = 1059.31M,
        ListPrice = 1431.50M, Type = "58"},

            new Car{
        Id = 101, Name = "Car 2", Color = "Blue", StandardCost = 959.31M,
        ListPrice = 1031.50M, Type = "58"},

            new Car{
        Id = 101, Name = "Car 3", Color = "Silver", StandardCost = 1159.31M,
        ListPrice = 1631.50M, Type = "58"},
            new Car{
        Id = 101, Name = "Car 4", Color = "Black", StandardCost = 1119.31M,
        ListPrice = 1531.50M, Type = "58"},
            new Car{
        Id = 101, Name = "Car 5", Color = "White", StandardCost = 1059.31M,
        ListPrice = 1431.50M, Type = "58"},
            new Car{
        Id = 101, Name = "Car 6", Color = "Black", StandardCost = 989.31M,
        ListPrice = 1131.50M, Type = "58"}
        };
    }
}



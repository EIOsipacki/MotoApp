

namespace MotoApp;

//using MotoApp.Components.DataProvider;
//using MotoApp.Data.Entities;
//using MotoApp.Data.Repositories;
//using System;
//using MotoApp.Components;
using MotoApp.Components.CsvReader;
//using MotoApp.Components.CsvReader.Models;
using MotoApp.Data;
using MotoApp.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;


public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly MotoAppDbContext _motoAppDbContext;

    public App(
       ICsvReader csvReader,
        MotoAppDbContext motoAppDbContext)
    {
        _csvReader = csvReader;
        _motoAppDbContext = motoAppDbContext;
        _motoAppDbContext.Database.EnsureCreated(); //czy stworzana BD jesli nie to 
    }
    public void Run()
    {
        //CreateXML();
        //QueryXML(); //read from xml file
         
        //SQL
        InsertDataToSqlBd();
        InsertDataToSqlBdManufacturer();

        Console.WriteLine(" Klik Any key");
        Console.ReadLine();

        var carsFromDb = _motoAppDbContext.Cars.ToList();
                  
        foreach (var item in carsFromDb)
        {
            Console.WriteLine($"\t{item.Name}: {item.Combined}");
        }
        Console.WriteLine(" Klik Any key");
        Console.ReadLine();

        var mansFromDb = _motoAppDbContext.Manufacturers.ToList();

        foreach (var item in mansFromDb)
        {
            Console.WriteLine($"Manufacturer: {item.Name}");
            Console.WriteLine($"\t{item.Country}: {item.Year}");
        }

    }

    private void InsertDataToSqlBd()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        foreach (var item in cars)
        {
            _motoAppDbContext.Cars.Add(new Car()
            {
                Manufacturer = item.Manufacturer,
                Name = item.Name,
                Year = item.Year,
                City = item.City,
                Combined = item.Combined,
                Cylinders = item.Cylinders,
                //Displacement = item.Displacement,
                Highway = item.Highway
            });
        }
        _motoAppDbContext.SaveChanges();
    }

    private void InsertDataToSqlBdManufacturer()
    {
        //items = manufacturers
        var manufacturers= _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");
        foreach (var man in manufacturers)
        {
            _motoAppDbContext.Manufacturers.Add(new Manufacturer()
            {
                Name = man.Name,
                Country = man.Country,
                Year = man.Year
                
            });
        }
        _motoAppDbContext.SaveChanges();
    }

    private static void QueryXML()
    {
        var document = XDocument.Load("fuel.xml");

        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")//filtrowanie
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void CreateXML()
    {
        var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

        //var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var document = new XDocument();
        var cars = new XElement("Cars", records
            .Select(x =>
            new XElement("Car",
                new XAttribute("Name", x.Name),
                new XAttribute("Combined", x.Combined),
                new XAttribute("Manufacturer", x.Manufacturer))));

        document.Add(cars);
        document.Save("fuel.xml");
    }
}



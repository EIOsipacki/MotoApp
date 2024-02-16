

namespace MotoApp;

//using MotoApp.Components.DataProvider;
//using MotoApp.Data.Entities;
//using MotoApp.Data.Repositories;
//using System;
//using MotoApp.Components;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;

    }
    public void Run()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

        var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var groups = manufacturers.GroupJoin(
            cars,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) =>
            new
            {
                Manufacturer = m,//wspólny klucz
                Cars = g
            })
            .OrderBy(x => x.Manufacturer.Name);
        
        foreach (var group in groups)
        {
            Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
            Console.WriteLine($"\t Cars: {group.Cars.Count()}");
            Console.WriteLine($"\t Max: {group.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"\t Min: {group.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"\t Avg: {group.Cars.Average(x => x.Combined)}");
            Console.WriteLine();

        }
        // scieżka do 
        //Console.WriteLine($" Cars: , {cars.Count()}, Man: {manufacturers.Count()}");

        ////group
        //var groups = cars
        //    .GroupBy(x => x.Manufacturer)
        //    .Select(g => new
        //    {
        //        Name = g.Key,
        //        Max = g.Max(c => c.Combined),
        //        Average = g.Average(c => c.Combined)
        //    })
        //    .OrderBy(x => x.Average);


        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"{group.Name}");
        //    Console.WriteLine($"\t Max: {group.Max}");
        //    Console.WriteLine($"\t Average: {group.Average:N2}");
        //}

        //join

        //var carsInCountry = cars.Join(
        //    manufacturers,
        //    x => x.Manufacturer,
        //    x => x.Name,
        //    (car, manufacturer) =>
        //        new
        //        {
        //            manufacturer.Country,
        //            car.Name,
        //            car.Combined

        //        })
        //    .OrderByDescending(x => x.Combined)
        //    .ThenBy(x => x.Name);

        //foreach (var item in carsInCountry)
        //{
        //    Console.WriteLine($"Country {item.Country}");
        //    Console.WriteLine($"\t Name: {item.Name}");
        //    Console.WriteLine($"\t Combined: {item.Combined}");
        //}

        //var carsInCountryKey = cars.Join(
        //    manufacturers,
        //    x => new { x.Manufacturer, x.Year},
        //    m => new {Manufacturer = m.Name, m.Year},
        //    (car, manufacturer) =>
        //        new
        //        {
        //            manufacturer.Country,
        //            car.Name,
        //            car.Combined

        //        })
        //    .OrderByDescending(x => x.Combined)
        //    .ThenBy(x => x.Name);

        //foreach (var item in carsInCountryKey)
        //{
        //    Console.WriteLine($"Country {item.Country}");
        //    Console.WriteLine($"\t Name: {item.Name}");
        //    Console.WriteLine($"\t Combined: {item.Combined}");
        //}












    }




}



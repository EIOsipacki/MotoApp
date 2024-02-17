

namespace MotoApp;

//using MotoApp.Components.DataProvider;
//using MotoApp.Data.Entities;
//using MotoApp.Data.Repositories;
//using System;
//using MotoApp.Components;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;

    }
    public void Run()
    {
        CreateXML();
        QueryXML(); //read from xml file

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



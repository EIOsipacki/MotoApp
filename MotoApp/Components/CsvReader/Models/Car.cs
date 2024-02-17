using MotoApp.Data.Entities;

namespace MotoApp.Components.CsvReader.Models;


//Model Year, Division, Carline, Eng Displ,# Cyl,City FE,Hwy FE,Comb FE
//2016,ALFA ROMEO,4C,1.8,4,24,34,28
public class Car : EntityBase
{
    public int Year { get; set; }

    public string? Manufacturer { get; set; }

    public string? Name { get; set; }

    //public double Displacement { get; set; }

    public int Cylinders { get; set; }

    public int City { get; set; }

    public int Highway { get; set; }

    public int Combined { get; set; }
}

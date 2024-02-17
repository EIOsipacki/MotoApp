using MotoApp.Components.CsvReader.Models;
using System.Runtime.CompilerServices;

namespace MotoApp.Components.CsvReader.Extensions;

public static class CarExtentions
{
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');
            //var dd = columns[3].Split('.');
            //string strdd = dd[0] + "," + dd[1];

            yield return new Car
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
               // Displacement = double.Parse(columns[3].ToString()),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7])
            };
        }
    }

    public static IEnumerable<Manufacturer> ToManufacturer(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');
            //var dd = columns[3].Split('.');
            //string strdd = dd[0] + "," + dd[1];

            yield return new Manufacturer
            {
                Name = columns[0],
                Country = columns[1],
                Year = int.Parse(columns[2])
            };
        }
    }


}


using MotoApp.Components.CarReader.Models;

namespace MotoApp.Components.CarReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);


    List<Manufacturer> ProcessManufacturers(string filePath);


}

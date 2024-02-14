namespace MotoApp.Components.DataProvider;

using MotoApp.Data.Entities;

public interface ICarsProvider
{

    //select (4 metody):
    List<Car> FilterCars(decimal minPrice);

    List<string> GetUniqueCarColors();

    decimal GetMinimumPriceOfAllCars();

    List<Car> GetSpecificColumns();

    void AnonymousClass();


    //order by
    List<Car> OrderByName();

    List<Car> OrderByNameDescending();

    List<Car> OrderByColorAndName();

    List<Car> OrderByColorAndNameDesc();

    //where 

    List<Car> WhereStartsWith(string prefix);

    List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    List<Car> WhereColorIs(string color);


    //first, last, single
    Car FirstByColor(string color);

    Car? FirstOrDefaultByColor(string color);

    Car FirstOrDefaultByColorWithDefault(string color);

    Car LastByColor(string color);

    Car SingleById(int Id);

    Car? SingleOrDefaultById(int id);


    //Take
    List<Car> TakeCars(int howMany);

    List<Car> TakeCars(Range range);

    List<Car> TakeCarsWhileNameStartsWith(string prefix);

    //Skip
    List<Car> SkipCars(int howMany);

    List<Car> SkipCarsWhileNameStartsWith(string prefix);

    //Distinct
    List<string> DistinktAllColors();
    List<Car> DistinktByColors();

    //Chunk
    List<Car[]> ChunkCars(int size);

}

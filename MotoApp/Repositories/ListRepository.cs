
using MotoApp.Entities;
using MotoApp.Repositories;
namespace MotoApp.Repositories;

public class ListRepository<T> : IRepository<T>
    where T : class, IEntity, new ()
     //wazna kolejność class i po nim IEntity
     //ograniczenie new() znaczy ze bazowa klasa po której dziedziczymy musi mieć bezparametrowy konstruktor

{
    protected readonly List<T> _items = new();

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
        //robi sie kopia nasze4j listy
    }

    public T CreateNewItem()
    //bez ograniczenia new() nie mogli by to stworzyć 
    {
        return new T();
    }

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public T? GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }

    public void Save()
    {
        //with  List do not used 

        //foreach (var item in _items)
        //{
        //    Console.WriteLine(item);
        //}
    }
}



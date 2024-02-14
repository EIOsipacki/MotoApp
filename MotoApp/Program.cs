using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CarReader;
using MotoApp.Components.DataProvider;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<ICsvReader, CsvReader>();



var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();




//using MotoApp.Repositories;
//using MotoApp.Entities;
//using MotoApp.Data;
//using MotoApp.Repositories.Extentions;

////var employeeRepository = new GenericRepository<Employee>();

////employeeRepository.Add(new Employee { FirstName = "Adam" });
////employeeRepository.Add(new Employee { FirstName = "Piotr" });
////employeeRepository.Add(new Employee { FirstName = "Zuzia" });
////employeeRepository.Save();
////Console.WriteLine($"  GetById (2) : {employeeRepository.GetById(2).ToString()}");


////var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
////employeeRepository.Add(new Employee { FirstName = "Adam" });
////employeeRepository.Add(new Employee { FirstName = "Piotr" });
////employeeRepository.Add(new Employee { FirstName = "Zuzia" });
////GetEmployeeById(employeeRepository);
////static void GetEmployeeById(IRepository<IEntity> employeeRepository)
////{
////    var employee = employeeRepository.GetById(2);
////    Console.Write(employee.ToString());
////}

////var itemAdded = new ItemAdded<Employee>(EmployeeAdded);

////moze być z Action 
////var itemAdded = new Action<Employee>(EmployeeAdded);
////var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), itemAdded);

////lub BEZ
//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;


////static void CreateNewDB()
////{
////    // подключаемся к БД, используя EF Core, обратите особое внимание на using
////    using var dbContext = new MotoAppDbContext();

////    // удаляем БД, если она существует
////    // это сделано специально, что-бы лишний раз вручную не удалять БД
////    dbContext.Database.EnsureDeleted();

////    // создаём БД, если она ещё не создана
////    // если она уже была создана, этот метод ничего не делает
////    dbContext.Database.EnsureCreated();
////}
////CreateNewDB();


//void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name} ");
//}


//AddEmployees(employeeRepository);
//WriteAllToConsole(employeeRepository);


//static void EmployeeAdded(Employee item)
//{
//    Console.WriteLine($"{item.FirstName} added");
//}



//void AddEmployees(IRepository<Employee> employeeRepository)
//{
//    var employees = new[]
//    {
//        new Employee { FirstName = "Adam" },
//        new Employee { FirstName = "Piotr" },
//        new Employee { FirstName = "Zuzia" } 
//    };

//    employeeRepository.AddBatch(employees);
//    //AddBatch(employeeRepository, employees);

//    //też moze byc
//    //AddBatch<Employee>(employeeRepository, employees);

//    //employeeRepository.Add(new Employee { FirstName = "Adam" });
//    //employeeRepository.Add(new Employee { FirstName = "Piotr" });
//    //employeeRepository.Add(new Employee { FirstName = "Zuzia" });
//    //employeeRepository.Save();
//}

//static void AddBusinessPartner(IRepository<BusinessPartner> repository)
//{
//    var items = new[]
//    {
//        new BusinessPartner { Name = "Adam" },
//        new BusinessPartner { Name = "Piotr" },
//        new BusinessPartner { Name = "Zuzia" }

//    };

//    repository.AddBatch(items);
//    "fgfh".AddBatch(items);
//    //AddBatch(repository, items);  
//}

////rosszerzenie metoda



////static void AddBatch<T>(IRepository<T> repository, T[] items)
////    where T: class, IEntity
////{
////    foreach (var item in items)
////    {
////        repository.Add(item);
////    }

////    repository.Save();
////}

//void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }        
//}


 



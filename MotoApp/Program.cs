using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using MotoApp.Repositories.Extentions;

//var employeeRepository = new GenericRepository<Employee>();

//employeeRepository.Add(new Employee { FirstName = "Adam" });
//employeeRepository.Add(new Employee { FirstName = "Piotr" });
//employeeRepository.Add(new Employee { FirstName = "Zuzia" });
//employeeRepository.Save();
//Console.WriteLine($"  GetById (2) : {employeeRepository.GetById(2).ToString()}");


//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
//employeeRepository.Add(new Employee { FirstName = "Adam" });
//employeeRepository.Add(new Employee { FirstName = "Piotr" });
//employeeRepository.Add(new Employee { FirstName = "Zuzia" });
//GetEmployeeById(employeeRepository);
//static void GetEmployeeById(IRepository<IEntity> employeeRepository)
//{
//    var employee = employeeRepository.GetById(2);
//    Console.Write(employee.ToString());
//}
var itemAdded = new ItemAdded(EmployeeAdded);
var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), itemAdded);
AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);


static void EmployeeAdded(object item)
{
    var employee = (Employee)item;
    Console.WriteLine($"{employee.FirstName} added");
}

void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee { FirstName = "Adam" },
        new Employee { FirstName = "Piotr" },
        new Employee { FirstName = "Zuzia" }

    };

    employeeRepository.AddBatch(employees);
    //AddBatch(employeeRepository, employees);

    //też moze byc
    //AddBatch<Employee>(employeeRepository, employees);

    //employeeRepository.Add(new Employee { FirstName = "Adam" });
    //employeeRepository.Add(new Employee { FirstName = "Piotr" });
    //employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    //employeeRepository.Save();
}

static void AddBusinessPartner(IRepository<BusinessPartner> repository)
{
    var items = new[]
    {
        new BusinessPartner { Name = "Adam" },
        new BusinessPartner { Name = "Piotr" },
        new BusinessPartner { Name = "Zuzia" }

    };

    repository.AddBatch(items);
    "fgfh".AddBatch(items);
    //AddBatch(repository, items);  
}

//rosszerzenie metoda



//static void AddBatch<T>(IRepository<T> repository, T[] items)
//    where T: class, IEntity
//{
//    foreach (var item in items)
//    {
//        repository.Add(item);
//    }

//    repository.Save();
//}

void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }        
}


 



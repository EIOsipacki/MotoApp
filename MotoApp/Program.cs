using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;

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

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
WriteAllToConsole(employeeRepository);

void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Adam" });
    employeeRepository.Add(new Employee { FirstName = "Piotr" });
    employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    employeeRepository.Save();
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Andrzej" });
    managerRepository.Add(new Manager { FirstName = "Aleksandra" });
    managerRepository.Add(new Manager { FirstName = "Tomek" });
    managerRepository.Save();
}
void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }        
}


 



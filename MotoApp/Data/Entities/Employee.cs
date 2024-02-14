namespace MotoApp.Data.Entities
{
    public class Employee : EntityBase
    {
        //public int Id { get; set; }

        public Employee()
        {

        }
        public Employee(string name)
        {

        }

        public string? FirstName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";

    }
}

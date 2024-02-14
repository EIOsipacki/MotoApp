using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;

namespace MotoApp.Data;


public class MotoAppDbContext : DbContext
{
    public MotoAppDbContext()
    {        
    }
    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase(databaseName: "StorageAppDB");
//        optionsBuilder.UseSqlServer(
//                    @"Server=(localdb)\mssqllocaldb;Database=MotoAppDb;Trusted_Connection=True;
//");

    }
}

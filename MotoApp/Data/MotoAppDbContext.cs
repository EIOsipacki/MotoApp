using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;

namespace MotoApp.Data;


public class MotoAppDbContext : DbContext
{
    //***** Framework INMEmory 
    //    public MotoAppDbContext()
    //    {        
    //    }
    //    public DbSet<Employee> Employees => Set<Employee>();

    //    public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder);
    //        optionsBuilder.UseInMemoryDatabase(databaseName: "StorageAppDB");
    ////        optionsBuilder.UseSqlServer(
    ////                    @"Server=(localdb)\mssqllocaldb;Database=MotoAppDb;Trusted_Connection=True;
    ////");
    //}

    //****END Framework In Memory

    public MotoAppDbContext(DbContextOptions<MotoAppDbContext> option)
        :base(option)
    {        
    }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine);





}


using Microsoft.EntityFrameworkCore;
using Test2S30964JakubKot.Models;

namespace Test2S30964JakubKot.Data;

public class DBContext : DbContext
{
    protected DBContext()
    {
    }

    public DBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<WashingProgram> Programs { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

   
    modelBuilder.Entity<Customer>().HasData(new List<Customer>
    {
        new Customer
        {
            CustomerId = 1,
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = null
        }
    });

    modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>
    {
        new WashingMachine
        {
            WashingMachineId = 1,
            SerialNumber = "WM2012/S431/12",
            MaxWeight = 32.23M
        },
        new WashingMachine
        {
            WashingMachineId = 2,
            SerialNumber = "WM2014/S491/28",
            MaxWeight = 52.23M
        }
    });

    modelBuilder.Entity<WashingProgram>().HasData(new List<WashingProgram>
    {
        new WashingProgram
        {
            ProgramId = 1,
            Name = "Quick wash",
            DurationMinutes = 69,
            TemperatureCelsius = 30
        },
        new WashingProgram
        {
            ProgramId = 2,
            Name = "Cotton Cycle",
            DurationMinutes = 143,
            TemperatureCelsius = 60
        },
        new WashingProgram
        {
            ProgramId = 3, 
            Name = "Synthetic",
            DurationMinutes = 90,
            TemperatureCelsius = 40
    }

    });

    modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>
    {
        new AvailableProgram
        {
            AvailableProgramId = 1,
            WashingMachineId = 1,
            ProgramId = 1,
            Price = 33.40M
        },
        new AvailableProgram
        {
            AvailableProgramId = 2,
            WashingMachineId = 2,
            ProgramId = 2,
            Price = 48.70M
        }
    });

    modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>
    {
        new PurchaseHistory
        {
            AvailableProgramId = 1,
            CustomerId = 1,
            PurchaseDate = DateTime.Parse("2025-06-03T09:00:00"),
            Rating = 4
        },
        new PurchaseHistory
        {
            AvailableProgramId = 2,
            CustomerId = 1,
            PurchaseDate = DateTime.Parse("2025-06-04T09:00:00"),
            Rating = null
        }
    });
}

}
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class AddressManagementDbContext(DbContextOptions<AddressManagementDbContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                Name = "Alex Figueroa",
                Birthday = new DateTime(2002, 9, 16),
                PhoneNumber = "8090000000",
                Email = "Alexfi2@gmail.com"
            },
            new Customer
            {
                Id = 2,
                Name = "Carla Gomez",
                Birthday = new DateTime(1995, 8, 19),
                PhoneNumber = "8091111111",
                Email = "gomcarla8@gmail.com"
            },
            new Customer
            {
                Id = 3,
                Name = "Luis Perez",
                Birthday = new DateTime(1999, 2, 4),
                PhoneNumber = "8092222222",
                Email = "lperez1999@gmail.com"
            }
        );

        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                AddressLine = "Bayona",
                Country = "Dominican Republic",
                State = "Santo Domingo",
                ZipCode = "10903",
                CustomerId = 1
            },
            new Address
            {
                Id = 2,
                AddressLine = "Cliffside Park",
                Country = "United States",
                State = "New Jersey",
                ZipCode = "07010",
                CustomerId = 2
            },
            new Address
            {
                Id = 3,
                AddressLine = "Las Caobas",
                Country = "Dominican Republic",
                State = "Santo Domingo",
                ZipCode = "10905",
                CustomerId = 1
            }
        );
    }
}
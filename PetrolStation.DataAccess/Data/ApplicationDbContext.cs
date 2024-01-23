using Microsoft.EntityFrameworkCore;
using PetrolStation.Models;

namespace Petrol_Station_Manegement_System.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        

        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<FuelPrice> FuelPrice { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pump> Pumps { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<FuelAddition> FuelAdditions { get; set; }
        public DbSet<FuelRequest> FuelRequests { get; set; }
        public DbSet<Crowding> Crowdings { get; set; }
        public DbSet<CashBox> CashBoxs { get; set; }
        public DbSet<EndShift> EndShifts { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<CustomerMessage> CustomerMessage { get; set; }


    }
}

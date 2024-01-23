using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.DataAccess.Repository
{
    public class UnitOfwork : IUnitOfwork
    {
        private ApplicationDbContext _db;

        public UnitOfwork(ApplicationDbContext db)
        {
            _db = db;
            Station = new StationRepository(_db);
            FuelType = new FuelTypeRepository(_db);
            FuelPrice = new FuelPriceRepository(_db);
            User = new UserRepository(_db);
            Tank = new TankRepository(_db);
            Shift = new ShiftRepository(_db);
            Employees = new EmployeeRepository(_db);
            Pump = new PumpRepository(_db);
            Supplier = new SupplierRepository(_db);
            FuelAddition = new FuelAdditionRepository(_db);
            FuelRequest = new FuelRequestRepository(_db);
            Crowding = new CrowdingRepository(_db);
            CashBox = new CashBoxRepository(_db);
            EndShift = new EndShiftRepository(_db);
            Payment = new PaymentRepository(_db);
            CustomerMessage = new CustomerMessageRepository(_db);
        }
        public IStationRepository Station { get; private set; }
        public IFuelTypeRepository FuelType { get; private set; }
        public IUserRepository User { get; private set; }
        public ITankRepository Tank { get; private set; }
        public IShiftRepository Shift { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IPumpRepository Pump { get; private set; }
        public IFuelPriceRepository FuelPrice { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public IFuelAdditionRepository FuelAddition { get; private set; }
        public IFuelRequestRepository FuelRequest { get; private set; }
        public ICrowdingRepository Crowding { get; private set; }
        public ICashBoxRepository CashBox { get; private set; }
        public IEndShiftRepository EndShift { get; private set; }
        public IPaymentRepository Payment { get; private set; }
        public ICustomerMessageRepository CustomerMessage { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

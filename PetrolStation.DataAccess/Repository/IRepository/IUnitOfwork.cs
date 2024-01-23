using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.DataAccess.Repository.IRepository
{
    public interface IUnitOfwork
    {
        IStationRepository Station { get; }
        IFuelTypeRepository FuelType { get; }
        IFuelPriceRepository FuelPrice { get; }
        IUserRepository User { get; }
        ITankRepository Tank { get; }
        IShiftRepository Shift { get; }
        IEmployeeRepository Employees { get; }
        IPumpRepository Pump { get; }
        ISupplierRepository Supplier { get; }
        IFuelAdditionRepository FuelAddition { get; }
        IFuelRequestRepository FuelRequest { get; }
        ICrowdingRepository Crowding { get; }
        ICashBoxRepository CashBox { get; }
        IEndShiftRepository EndShift { get; }
        IPaymentRepository Payment { get; }
        ICustomerMessageRepository CustomerMessage { get; }

        void Save();
    }
}

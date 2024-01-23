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
    public class FuelAdditionRepository : Repository<FuelAddition>, IFuelAdditionRepository
    {
        private ApplicationDbContext _db;

        public FuelAdditionRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(FuelAddition obj)
        {
            var objFromDb = _db.FuelAdditions.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.PurchasingFuelPrice = obj.PurchasingFuelPrice;
                objFromDb.QuantityAdded = obj.QuantityAdded;
                objFromDb.Date = obj.Date;
                objFromDb.FuelTypeId = obj.FuelTypeId;
                objFromDb.TankId = obj.TankId;
                

            }
        }
    }
}

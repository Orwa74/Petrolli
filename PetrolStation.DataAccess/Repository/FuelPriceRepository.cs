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
    public class FuelPriceRepository : Repository<FuelPrice>, IFuelPriceRepository
    {
        private ApplicationDbContext _db;

        public FuelPriceRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(FuelPrice obj)
        {
            var objFromDb = _db.FuelPrice.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.PurrechasingPrice = obj.PurrechasingPrice;
                objFromDb.SelingPrice = obj.SelingPrice;
                objFromDb.FuelTypeId = obj.FuelTypeId;
                objFromDb.Date = obj.Date;

            }
        }
    }
}

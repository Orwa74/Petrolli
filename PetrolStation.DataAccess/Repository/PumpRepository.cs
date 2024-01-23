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
    public class PumpRepository : Repository<Pump>, IPumpRepository
    {
        private ApplicationDbContext _db;

        public PumpRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Pump obj)
        {
            var objFromDb = _db.Pumps.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.CurrerntMeter = obj.CurrerntMeter;
                objFromDb.Status = obj.Status;
                objFromDb.LastUpdated = obj.LastUpdated;
                objFromDb.TankId = obj.TankId;
                objFromDb.FuelTypeId = obj.FuelTypeId;
                objFromDb.PumpCode = obj.PumpCode;

            }
        }
    }
}

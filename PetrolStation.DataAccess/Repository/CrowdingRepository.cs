using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.DataAccess.Repository
{
    public class CrowdingRepository : Repository<Crowding>, ICrowdingRepository
    {
        private ApplicationDbContext _db;

        public CrowdingRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Crowding obj)
        {
            var objFromDb = _db.Crowdings.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FuelTypeId = objFromDb.FuelTypeId;
                objFromDb.Level = obj.Level;
                objFromDb.LastUpdate = obj.LastUpdate;
            }
        }
    }
}

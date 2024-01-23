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
    public class FuelTypeRepository : Repository<FuelType>, IFuelTypeRepository
    {
        private ApplicationDbContext _db;

        public FuelTypeRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(FuelType obj)
        {
            var objFromDb = _db.FuelTypes.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Fuel_Type = obj.Fuel_Type;
            }
        }
    }
}

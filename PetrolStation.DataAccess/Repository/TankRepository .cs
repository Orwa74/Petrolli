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
    public class TankRepository : Repository<Tank>, ITankRepository
    {
        private ApplicationDbContext _db;

        public TankRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Tank obj)
        {
            var objFromDb = _db.Tanks.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Capacity = obj.Capacity;
                objFromDb.Current_Quantity = obj.Current_Quantity;
                objFromDb.FuelTypeId = obj.FuelTypeId;
                objFromDb.TankName = obj.TankName;

            }
        }
    }
}

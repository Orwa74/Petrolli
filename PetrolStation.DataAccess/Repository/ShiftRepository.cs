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
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        private ApplicationDbContext _db;

        public ShiftRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Shift obj)
        {
            var objFromDb = _db.Shifts.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.StartTime = obj.StartTime;
                objFromDb.EndTime = obj.EndTime;
            }
        }
    }
}

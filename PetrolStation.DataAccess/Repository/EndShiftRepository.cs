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
    public class EndShiftRepository : Repository<EndShift>, IEndShiftRepository
    {
        private ApplicationDbContext _db;

        public EndShiftRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(EndShift obj)
        {
            var objFromDb = _db.EndShifts.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Notes = obj.Notes;
                objFromDb.Price = obj.Price;
                objFromDb.PumpId = obj.PumpId;
                objFromDb.ShiftId = obj.ShiftId;
                objFromDb.CashBoxId = obj.CashBoxId;
                objFromDb.Date = obj.Date;
                objFromDb.EmployeeId = obj.EmployeeId;

            }
        }
    }
}

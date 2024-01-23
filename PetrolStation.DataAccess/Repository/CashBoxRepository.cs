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
    public class CashBoxRepository : Repository<CashBox>, ICashBoxRepository
    {
        private ApplicationDbContext _db;

        public CashBoxRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(CashBox obj)
        {
            var objFromDb = _db.CashBoxs.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.CurrentAmount = obj.CurrentAmount;
                objFromDb.Date = obj.Date;
                

            }
        }
    }
}

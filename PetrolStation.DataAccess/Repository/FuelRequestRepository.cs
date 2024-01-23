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
    public class FuelRequestRepository : Repository<FuelRequest>, IFuelRequestRepository
    {
        private ApplicationDbContext _db;

        public FuelRequestRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(FuelRequest obj)
        {
            var objFromDb = _db.FuelRequests.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FuelTypeId = obj.FuelTypeId;

                objFromDb.Amount = obj.Amount;
                objFromDb.SupplierId = obj.SupplierId;
                objFromDb.JoinDate = obj.JoinDate;
                objFromDb.Notes = obj.Notes;
                

            }
        }
    }
}

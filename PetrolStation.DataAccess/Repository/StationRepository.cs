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
    public class StationRepository : Repository<Station>, IStationRepository
    {
        private ApplicationDbContext _db;

        public StationRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Station obj)
        {
            var objFromDb = _db.Stations.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Location = obj.Location;
                objFromDb.Address = obj.Address;
                objFromDb.Email = obj.Email;
                objFromDb.Phone = obj.Phone;
            }
        }
    }
}

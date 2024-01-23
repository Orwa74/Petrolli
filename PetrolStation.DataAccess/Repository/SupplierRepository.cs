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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private ApplicationDbContext _db;

        public SupplierRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Supplier obj)
        {
            var objFromDb = _db.Suppliers.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Email = obj.Email;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.Address = obj.Address;
            }
        }
    }
}

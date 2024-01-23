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
    public class CustomerMessageRepository : Repository<CustomerMessage>, ICustomerMessageRepository
    {
        private ApplicationDbContext _db;

        public CustomerMessageRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(CustomerMessage obj)
        {
            var objFromDb = _db.CustomerMessage.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Email = obj.Email;
                objFromDb.Message = obj.Message;
                objFromDb.SendTime = obj.SendTime;
            }
        }
    }
}

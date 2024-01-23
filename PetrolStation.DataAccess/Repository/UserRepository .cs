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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(User obj)
        {
            var objFromDb = _db.Users.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.UserName = obj.UserName;
                objFromDb.Email = obj.Email;
            }
        }
    }
}

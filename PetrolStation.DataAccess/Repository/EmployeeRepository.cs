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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Employee obj)
        {
            var objFromDb = _db.Employees.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FirstName = obj.FirstName;
                objFromDb.LastName = obj.LastName;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.Email = obj.Email;
                objFromDb.ShiftId = obj.ShiftId;
                objFromDb.Role = obj.Role;
                objFromDb.JoinDate = obj.JoinDate;
                objFromDb.Salary = obj.Salary;

            }
        }
    }
}

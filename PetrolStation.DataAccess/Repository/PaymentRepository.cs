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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private ApplicationDbContext _db;

        public PaymentRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       

        public void Update(Payment obj)
        {
            var objFromDb = _db.Payment.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Date = obj.Date;
                objFromDb.Description= obj.Description;
                objFromDb.ThePrice= obj.ThePrice;
                objFromDb.EmployeeId = obj.EmployeeId;
                objFromDb.CashBoxId = obj.CashBoxId;
                objFromDb.Type = obj.Type;

            }
        }
    }
}

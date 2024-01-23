using PetrolStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.DataAccess.Repository.IRepository
{
    public interface IAuthRepository 
    {
       Task<User> Register (User user, string password);
        Task<User> Login (string Name, string password);

        Task<bool> UserExists(string username);

        Task<User> GetUserByName(string username);
    }
}

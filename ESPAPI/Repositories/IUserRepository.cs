using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESPAPI.Models;
namespace ESPAPI.Repositories
{
    public interface IUserRepository
    {
        int AddNewUser(User u);
        User GetUser(string UserName, string Password);
        User GetUserById(string Id);
        User GetUserByEmail(string Email);
        User GetUserByEmailAndUserName(string Email , string UserName);
        int UpdateUser(string id, User u);
    }
}

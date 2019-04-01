using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESPAPI.Models;
namespace ESPAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private IespContext _context;

        public UserRepository(IespContext context)
        {
            _context = context;
        }

        public User GetUserById(string Id)
        {
            var user = _context.user.SingleOrDefault(a => a.Id ==Id);
            return user;
        }

        public User GetUser(string UserName,string Password)
        {
            var u = _context.user.SingleOrDefault(a => a.UserName==UserName && a.PasswordHash==Password);
            return u;
        }
        public User GetUserByEmail(string Email)
        {
            var user = _context.user.SingleOrDefault(a => a.Email==Email);
            return user;
        }

        public User GetUserByEmailAndUserName(string Email,string UserName)
        {
            var user = _context.user.SingleOrDefault(a => a.Email == Email && a.UserName==UserName);
            return user;
        }

        public int AddNewUser(User user)
        {
            int insertSuccess = 0;          
            user.Id =Convert.ToString( Guid.NewGuid());
            _context.user.Add(user);
            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }

        public int UpdateUser(string id, User user)
        {
            int updateSuccess = 0;
            var target = _context.user.SingleOrDefault(a => a.Id == id);
            if (target != null)
            {
                _context.Entry(target).CurrentValues.SetValues(user);
                updateSuccess = _context.SaveChanges();
            }
            return updateSuccess;
        }
    }
}

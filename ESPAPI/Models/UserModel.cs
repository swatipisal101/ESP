using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPAPI.Models
{
    public class UserModel
    {
    }

    public class User
    {
        //public Guid? Id { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public string RoleId { get; set; }          
        public string Email { get; set; }      
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class resetuserpassmodel
    {
        public string email { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        //public string password { get; set; }
        public string currpassword { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }
        public string token { get; set; }
    }

    //public class UserRole
    //{
    //    public Guid? RoleId { get; set; }
    //    public string RoleName { get; set; }
    //}
}

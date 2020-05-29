using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public int RoleId { set; get; }
        public virtual Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}

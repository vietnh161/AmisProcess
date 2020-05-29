using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Role
    {
        public int Id { set; get; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}

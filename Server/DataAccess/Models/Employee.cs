using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ProcessRunning = new HashSet<ProcessRunning>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FrirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProcessRunning> ProcessRunning { get; set; }
    }
}

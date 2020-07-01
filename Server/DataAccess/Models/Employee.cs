using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            PhaseEmployee = new HashSet<PhaseEmployee>();
            ProcessRunning = new HashSet<ProcessRunning>();
        }

        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PhaseEmployee> PhaseEmployee { get; set; }
        public virtual ICollection<ProcessRunning> ProcessRunning { get; set; }
    }
}

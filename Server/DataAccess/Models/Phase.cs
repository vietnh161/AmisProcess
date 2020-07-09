using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Phase
    {
        public Phase()
        {
            Field = new HashSet<Field>();
            PhaseEmployee = new HashSet<PhaseEmployee>();
            ProcessRunning = new HashSet<ProcessRunning>();
        }

        public Guid PhaseId { get; set; }
        public int Serial { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TimeImplement { get; set; }
        public string TimeImplementType { get; set; }
        public string EmployeeImplementType { get; set; }
        public string EmployeeImplement { get; set; }
        public int? Posittion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid ProcessId { get; set; }

        public virtual Process Process { get; set; }
        public virtual ICollection<Field> Field { get; set; }
        public virtual ICollection<PhaseEmployee> PhaseEmployee { get; set; }
        public virtual ICollection<ProcessRunning> ProcessRunning { get; set; }
    }
}

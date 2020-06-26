using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Phase
    {
        public Phase()
        {
            Field = new HashSet<Field>();
            ProcessRunning = new HashSet<ProcessRunning>();
        }

        public int PhaseId { get; set; }
        public int Serial { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TimeImplement { get; set; }
        public string TimeImplementType { get; set; }
        public string EmployeeImplementType { get; set; }
        public string EmployeeImplement { get; set; }
        public byte? IsLastPhase { get; set; }
        public byte? IsFirstPhase { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ProcessId { get; set; }

        public virtual Process Process { get; set; }
        public virtual ICollection<Field> Field { get; set; }
        public virtual ICollection<ProcessRunning> ProcessRunning { get; set; }
    }
}

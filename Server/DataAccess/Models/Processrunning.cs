using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ProcessRunning
    {
        public ProcessRunning()
        {
            Fieldvalue = new HashSet<FieldValue>();
        }

        public int ProcessRunningId { get; set; }
        public int EmployeeId { get; set; }
        public int PhaseId { get; set; }
        public int? EmployeeHandleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Phase Phase { get; set; }
        public virtual ICollection<FieldValue> Fieldvalue { get; set; }
    }
}

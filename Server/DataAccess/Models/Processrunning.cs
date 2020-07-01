using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ProcessRunning
    {
        public ProcessRunning()
        {
            FieldValue = new HashSet<FieldValue>();
        }

        public Guid ProcessRunningId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PhaseId { get; set; }
        public string EmployeeHandleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public sbyte? Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Phase Phase { get; set; }
        public virtual ICollection<FieldValue> FieldValue { get; set; }
    }
}

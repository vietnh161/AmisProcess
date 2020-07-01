using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PhaseEmployee
    {
        public Guid PhaseEmployeeId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PhaseId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Phase Phase { get; set; }
    }
}

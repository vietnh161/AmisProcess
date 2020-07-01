using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Process
    {
        public Process()
        {
            Phase = new HashSet<Phase>();
        }

        public Guid ProcessId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Status { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Phase> Phase { get; set; }
    }
}

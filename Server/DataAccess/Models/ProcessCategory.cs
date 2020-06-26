using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ProcessCategory
    {
        public ProcessCategory()
        {
            Process = new HashSet<Process>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Process> Process { get; set; }
    }
}

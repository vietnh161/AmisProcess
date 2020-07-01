using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Process = new HashSet<Process>();
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Process> Process { get; set; }
    }
}

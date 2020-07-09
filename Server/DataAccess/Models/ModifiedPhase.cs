using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class ModifiedPhase
    {
        public Guid ProcessId { get; set; }
        public List<Guid> ListPhaseDelete { get; set; }
        public List<Guid> ListFieldDelete { get; set; }

        public List<Guid> ListEmployeeDelete { get; set; }

        public virtual ICollection<Phase> Phase { get; set; }
    }
}

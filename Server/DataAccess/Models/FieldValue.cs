using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class FieldValue
    {
        public Guid Id { get; set; }
        public Guid ProcessRunningId { get; set; }
        public Guid FieldId { get; set; }
        public string Value { get; set; }
        public string ValueForCheckBox { get; set; }

        public virtual Field Field { get; set; }
        public virtual ProcessRunning ProcessRunning { get; set; }
    }
}

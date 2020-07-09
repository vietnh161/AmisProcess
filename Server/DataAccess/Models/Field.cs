using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Field
    {
        public Field()
        {
            FieldOption = new HashSet<FieldOption>();
            FieldValue = new HashSet<FieldValue>();
        }

        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public sbyte? Required { get; set; }
        public Guid PhaseId { get; set; }

        public virtual Phase Phase { get; set; }
        public virtual ICollection<FieldOption> FieldOption { get; set; }
        public virtual ICollection<FieldValue> FieldValue { get; set; }
    }
}

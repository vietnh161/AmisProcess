using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Field
    {
        public Field()
        {
            FieldValue = new HashSet<FieldValue>();
            Option = new HashSet<Option>();
        }

        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public sbyte? Required { get; set; }
        public Guid PhaseId { get; set; }

        public virtual Phase Phase { get; set; }
        public virtual ICollection<FieldValue> FieldValue { get; set; }
        public virtual ICollection<Option> Option { get; set; }
    }
}

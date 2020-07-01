using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Option
    {
        public Guid OptionId { get; set; }
        public string Value { get; set; }
        public Guid FieldId { get; set; }

        public virtual Field Field { get; set; }
    }
}

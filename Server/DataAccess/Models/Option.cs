using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Option
    {
        public int OptionId { get; set; }
        public string Value { get; set; }
        public int? FieldId { get; set; }

        public virtual Field Field { get; set; }
    }
}

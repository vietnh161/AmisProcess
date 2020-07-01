using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Processcategory
    {
        public int Guid { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
    }
}

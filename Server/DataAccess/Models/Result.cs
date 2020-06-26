using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Result<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalRow { get; set; }
    }
}

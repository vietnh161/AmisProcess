using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Paging
    {
        public int CurrentPage { set; get; }
        public int PageSize { set; get; }

        public string Sort { set; get; }
        public string SortBy { set; get; }

        public  IEnumerable<Filter> Filters { set; get; } 
      
    }

    public class Filter
    {
        public string Value { set; get; }
        public string Property { set; get; }
    }
}

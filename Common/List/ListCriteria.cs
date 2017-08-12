using System.Collections.Generic;

namespace Common.List
{
    public class ListCriteria
    {
        public ListCriteria()
        {
            Sorts = new List<SortOrder>();
            Filters = new List<Filter>();
        }

        public int Skip { get; set; }

        public int Take { get; set; }

        public bool SkipPaging { get; set; }

        public List<SortOrder> Sorts { get; set; }

        public List<Filter> Filters { get; set; }
    }
}
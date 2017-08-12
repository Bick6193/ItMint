using System.Collections.Generic;

namespace Common.List
{
    public class ListResult<T>
    {
        public List<T> Data { get; set; }

        public int FilteredTotal { get; set; }

        public int Total { get; set; }
    }
}
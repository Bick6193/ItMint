using System.Collections.Generic;
using System.Linq;

namespace Common.List
{
    public class SortOrder
    {
        public SortOrder()
        {

        }

        public SortOrder(string field, string direction):this()
        {
            Field = field;
            Direction = direction;
        }

        public string Field { get; set; }

        public string Direction { get; set; }

        public List<string> Path => Field.Split('.').Select(x => x.ToPascalCase()).ToList();
    }
}
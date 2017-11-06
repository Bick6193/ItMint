using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Metadata
    {
        public int MetaDataId { get; set; }

        public string Controller { get; set; } = "";

        public string Action { get; set; } = "";

        public string Keywords { get; set; } = "";

        public string Description { get; set; } = "";

        public string Title { get; set; } = "";

        public string Author { get; set; } = "";
    }
}

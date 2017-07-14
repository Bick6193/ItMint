using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class MetaData
    {
        public int MetaDataId { get; set; }
        public string Controller { get; set; } = "";
        public string Action { get; set; } = "";
        public string Keywords { get; set; } = "";
        public string Description { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";

        public byte[] RowVersion { get; set; }
    }
}

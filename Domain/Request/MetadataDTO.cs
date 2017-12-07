using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Request
{
  public class MetadataDTO
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

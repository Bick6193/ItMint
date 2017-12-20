using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
  public class DownloadFileViewModel
  {
    public int IdRequest { get; set; }

    public int IdFile { get; set; }

    public string FileName { get; set; }
  }
}

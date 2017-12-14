using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Request
{
  public class ProjectFileDTO
  {
    public List<string> listFile { get; set; }

    public string Version { get; set; }
  }
}

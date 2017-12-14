using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
  public class ProjectFile
  {
    public int Id { get; set; }

    public string ProjectId { get; set; }

    public string FileName { get; set; }

    public string DefaultFolder { get; set; }

    public string VersionFolder { get; set; }

    public virtual Projects Project { get; set; }
    
    public DateTime RevisionTime { get; set; }

  }
}

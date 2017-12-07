using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
  public class ProjectFile
  {
    public int Id { get; set; }

    public string FileName { get; set; }

    public int ProjectFormId { get; set; }

    public virtual Projects Project { get; set; }

    public int FileDataId { get; set; }

    public virtual BinaryProjectFileData FileData { get; set; }

  }
}

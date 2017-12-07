using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
  public class Revision
  {
    public int Id { get; set; }

    public DateTime RevisionTime { get; set; }

    public virtual Projects Projects { get; set; }
  }
}

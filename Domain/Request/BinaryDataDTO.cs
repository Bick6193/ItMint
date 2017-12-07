using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Domain.Request
{
  public class BinaryDataDTO
  {
    [Key]
    public int Id { get; set; }

    public byte[] Content { get; set; }

    public virtual FileDTO File { get; set; }
  }
}

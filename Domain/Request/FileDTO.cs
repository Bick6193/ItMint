﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Domain.Request
{
  public class FileDTO
  {
    public int Id { get; set; }

    [StringLength(255)]
    public string FileName { get; set; }

    [StringLength(100)]
    public string ContentType { get; set; }

    public int? RequestFormId { get; set; }

    public string RequestFormToken { get; set; }

    public int? FileIndex { get; set; }

    public int BinaryDataId { get; set; }

    public BinaryDataDTO BinaryData { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Request
{
  public class ProjectDTO
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public string Description { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }
  }
}

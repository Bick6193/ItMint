using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
  public class ProjectViewModel
  {
    public int Id { get; set; }

    public string ProjectId { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public string Description { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }

    public DateTime RevisionTime { get; set; }

    public string VersionFolder { get; set; }
  }
}

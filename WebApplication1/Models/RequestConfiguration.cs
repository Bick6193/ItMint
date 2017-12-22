using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
  public class RequestConfiguration
  {
    public IEnumerable<string> Types { get; set; }

    public string Location { get; set; }
  }
}

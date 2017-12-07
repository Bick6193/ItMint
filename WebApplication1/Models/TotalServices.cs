using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
  public class TotalServices
  {
    public int NotViewed { get; set; }

    public DateTime LatestRequest { get; set; }

    public int TotalRequest { get; set; }

    public List<string> TopTypes { get; set; }

    public List<string> TopCountry { get; set; }
  }
}

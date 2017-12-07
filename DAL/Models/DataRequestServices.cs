using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
  public class DataRequestServices
  {
    public int NotViewed { get; set; }

    public int TotalRequests { get; set; }

    public DateTime LatestRequest { get; set; }

    public List<string> TopTypes { get; set; }

    public List<string> TopCountry { get; set; }
  }
}

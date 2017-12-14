using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
  public class RequestTypesViewModel
  {
    public int Id { get; set; }

    public string Type { get; set; }

    public string EmployeesEmail { get; set; }

    public int Count { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsDefault { get; set; }

    public string Color { get; set; }
  }
}

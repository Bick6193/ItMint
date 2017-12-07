using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
  public class RequestViewModel
  {
    public int RequestId { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Description { get; set; }

    public string Country { get; set; }

    public bool Viewed { get; set; }

    public int? RequestTypeId { get; set; }

    public string RequestTypeInString { get; set; }

    public DateTime Date { get; set; }

    public string UserId { get; set; }
  }
}

using System;
using System.Collections.Generic;

namespace DAL.Models
{
  public sealed class Request
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Country { get; set; }

    public string Description { get; set; }

    public bool Viewed { get; set; }

    public bool Flag { get; set; }

    public int? RequestTypeId { get; set; }

    public string RequestTypeInString { get; set; }

    public List<File> Files { get; set; }

    public DateTime Date { get; set; }

    public string UserId { get; set; }
  }
}

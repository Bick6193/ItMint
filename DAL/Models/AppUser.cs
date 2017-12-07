
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
  public class AppUser
  {
    public int Id { get; set; }

    public string Login { get; set; }

    public string Position { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public UserType Type { get; set; }

    public bool Active { get; set; }

    public bool ForceToResetPassword { get; set; }

    public bool IsAdministrative { get; set; }
  }
}

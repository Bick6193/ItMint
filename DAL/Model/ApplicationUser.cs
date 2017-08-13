using System.Collections.Generic;
using Domain;

namespace DAL.Model
{
    public class ApplicationUser : EntityBase
    {
    public string Login { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string FullName { get; set; }

      public string Email { get; set; }

      public string Password { get; set; }

      public UserType Type { get; set; }

      public bool Active { get; set; }

      public bool ForceToResetPassword { get; set; }

      public bool IsAdministrative { get; set; }

      public bool CanEdit { get; set; }
    
      public virtual List<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
    }
}

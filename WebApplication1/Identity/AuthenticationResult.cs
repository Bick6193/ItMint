
using System.Collections.Generic;
using DAL.Model;
using Domain.User;

namespace Web.Identity
{
  public class AuthenticationResult
  {
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public int ExpiresIn { get; set; }

    public Dictionary<int, int> Permissions { get; set; }

    public ApplicationUserLogin User { get; set; }

    public bool Administrative { get; set; }
  }
}

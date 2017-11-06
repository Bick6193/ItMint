using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Models;
using Domain;
using UserType = DAL.Models.UserType;

namespace DAL.SeedMamagers
{
  public class BasicSeedManager
  {
    private ApplicationContext Context { get; }

    private string SystemUserLogin => "System";

    public BasicSeedManager(ApplicationContext context)
    {
      Context = context;
    }

    public void Seed()
    {
      PopulateSystemUser();
    }

    private void PopulateSystemUser()
    {
      if (!Context.ApplicationUsers.Any(x => x.Id == 1 && string.Equals(x.Login, SystemUserLogin, StringComparison.CurrentCultureIgnoreCase)))
      {
        Context.ApplicationUsers.Add(new AppUser()
        {
          Id = 1,
          Login = SystemUserLogin,
          IsAdministrative = true,
          Email = "test@test.com",
          Type = UserType.Admin,
          FirstName = "System",
          LastName = "System",
          FullName = "System System",
          Password = "System",
          ForceToResetPassword = false //todo!!
        });
        Context.SaveChanges();
      }
    }

    private void PopulateRoles()
    {

    }
  }
}

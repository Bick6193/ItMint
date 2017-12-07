using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Model;
using DAL.Models;
using Domain;
using Domain.Authorization;
using Microsoft.EntityFrameworkCore;
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
      PopulateRequestTypes();
      PopulateRequest();
      PopulateTokenConfig();
    }

    private void PopulateSystemUser()
    {
      if (!Context.ApplicationUsers.Any(x =>
        x.Id == 1 && string.Equals(x.Login, SystemUserLogin, StringComparison.CurrentCultureIgnoreCase)))
      {
        Context.ApplicationUsers.Add(new AppUser()
        {
          Login = SystemUserLogin,
          IsAdministrative = true,
          Email = "test@test.com",
          Type = UserType.Admin,
          FullName = "System System",
          PhoneNumber = "123123123",
          Position = "System",
          Active = true,
          Password = "System",
          ForceToResetPassword = false //todo!!
        });
        Context.SaveChanges();
      }
    }

    private void PopulateRequest()
    {
      if (!Context.Requests.Any(x => x.Id == 1 && x.Id == 2))
      {
        Context.Requests.Add(new Request()
        {
          Name = "Sviridovich Nikita",
          Phone = "+37529691469",
          Email = "nikita.sviridovich@itmint.ca",
          Description = "Some Description",
          Country = "Minsk, Belarus",
          Viewed = false,
          Flag = false,
          RequestTypeId = null,
          RequestTypeInString = "Web Development",
          Date = DateTime.Now,
          UserId = "SomeID"
        });
        Context.Requests.Add(new Request()
        {
          Name = "Makarov Makar",
          Phone = "+375296280339",
          Email = "makarov.makar@mail.ru",
          Description = "Some Description",
          Country = "Brest, Belarus",
          Viewed = false,
          Flag = false,
          RequestTypeId = null,
          RequestTypeInString = "Design",
          Date = DateTime.Now,
          UserId = "SomeID"
        });
        Context.SaveChanges();
      }
    }

    private void PopulateTokenConfig()
    {
      if (!Context.ApiUsers.Any(x => x.ClientId.Equals("ngApp")))
      {
        Context.ApiUsers.Add(new ApiUser()
        {
          ClientId = "ngApp",
          Active = true,
          ApplicationType = ApplicationType.JavaScript,
          Secret = "",
          Name = "ngApp",
          RefreshTokenLifeTime = 600,
        });
      }
      Context.SaveChanges();
    }

    private void PopulateRequestTypes()
    {
      if (!Context.RequestsType.Any(x => x.Id == 1))
      {
        Context.RequestsType.Add(new RequestType()
        {
          Type = "Web Development",
          Color = "text-type",
          EmployeesEmail = "nikita.sviridovich@itmint.ca",
          EmployeesName = "ItMint Team",
          IsDefault = true,
          IsEnabled = true,
          MessageToCustomer = "Header",
          MessageBodyToCustomer = "Body"
        });
        Context.SaveChanges();
      }
    }
  }
}
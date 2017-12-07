using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Common.List;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.Request;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
  {
    private ApplicationContext ApplicationContext { get; }

    public ApplicationUserRepository(ApplicationContext context) : base(context)
    {
      ApplicationContext = context;
    }

    public List<UserDTO> GetAll()
    {
      List<UserDTO> userDto = new List<UserDTO>();
      var items = from i in ApplicationContext.ApplicationUsers select i;
      foreach (var collection in items)
      {
        userDto.Add(new UserDTO
        {
          Id = collection.Id,
          FullName = collection.FullName,
          Email = collection.Email,
          Position = collection.Position,
          Active = collection.Active
        });

      }
      return userDto;

    }

    public UserDTO FindByLogin(string username)
    {
      return Mapper.Map<UserDTO>(ApplicationContext.ApplicationUsers.FirstOrDefault(x => x.Email == username));
    }

    public UserDTO GetById(int id)
    {
      return Mapper.Map<UserDTO>(ApplicationContext.ApplicationUsers.FirstOrDefault(x => x.Id == id));

    }

    public void Create(AppUser appUser)
    {
      ApplicationContext.ApplicationUsers.Add(appUser);
      ApplicationContext.SaveChanges();
    }

    public int ReturnId(AppUser appUser)
    {
      return ApplicationContext.ApplicationUsers.Where(x => x.Email == appUser.Email).Select(x => x.Id).LastOrDefault();
    }
    public void Update(AppUser appUser)
    {
      ApplicationContext.ApplicationUsers.Update(appUser);
    }

    public void UpdatePassword(AppUser appUser)
    {
      var items = ApplicationContext.ApplicationUsers.Where(x => x.Id == appUser.Id);
      foreach (var item in items)
      {
        item.Password = appUser.Password;
      }
      ApplicationContext.SaveChanges();
    }
    public void Delete(int id)
    {
      var item = (ApplicationContext.ApplicationUsers.Where(x => x.Id == id)).FirstOrDefault();
      if (item != null)
      {
        ApplicationContext.ApplicationUsers.Remove(item);
        ApplicationContext.SaveChanges();
      }
    }
  }
}

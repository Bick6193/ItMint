using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Common.List;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
  {
    public ApplicationUserRepository(ApplicationContext context) : base(context)
    {

    }

    public IEnumerable<AppUser> GetAll()
    {
      throw new NotImplementedException();
    }

    public ApplicationUserLogin FindByLogin(string username)
    {
      return null;
    }

    public AppUser GetById(int id)
    {
      throw new NotImplementedException();
    }

    public void Create(AppUser appUser)
    {
      throw new NotImplementedException();
    }

    public void Update(AppUser appUser)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}

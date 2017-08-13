using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Common.List;
using DAL.Context;
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


    public ListResult<ApplicationUserDisplay> List(ListCriteria criteria)
    {
      throw new NotImplementedException();
    }

    public ApplicationUserLogin FindByLogin(string username)
    {
      var user = Mapper.Map<ApplicationUserLogin>(Context.ApplicationUsers.FirstOrDefault(u => u.Login == username));
      if (user != null)
      {
        var roles = Context.Roles.Include(x => x.RolePermissions)
                      .Where(r => r.Users.Any(u => u.UserId == user.Id))
                      .ToList();
        user.Roles.AddRange(Mapper.Map<List<RoleDetails>>(roles));
      }
      return user;
    }
  }
}

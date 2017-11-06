using System.Collections.Generic;
using Common.List;
using DAL.Models;
using Domain.User;
using JetBrains.Annotations;

namespace DAL.Repositories.Infrastructure
{
  public interface IApplicationUserRepository
  {
    [NotNull]
    [MustUseReturnValue]
    IEnumerable<AppUser> GetAll();

    [CanBeNull]
    [MustUseReturnValue]
    ApplicationUserLogin FindByLogin([NotNull] string username);

    [CanBeNull]
    [MustUseReturnValue]
    AppUser GetById(int id);

    void Create(AppUser appUser);

    void Update(AppUser appUser);

    void Delete(int id);

  }
}
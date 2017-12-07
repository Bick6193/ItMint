using System.Collections.Generic;
using Common.List;
using DAL.Models;
using Domain.Request;
using Domain.User;
using JetBrains.Annotations;

namespace DAL.Repositories.Infrastructure
{
  public interface IApplicationUserRepository
  {
    [NotNull]
    [MustUseReturnValue]
    List<UserDTO> GetAll();

    [CanBeNull]
    [MustUseReturnValue]
    UserDTO FindByLogin([NotNull] string username);

    [CanBeNull]
    [MustUseReturnValue]
    UserDTO GetById(int id);

    void Create(AppUser appUser);

    int ReturnId(AppUser appUser);

    void Update(AppUser appUser);

    void UpdatePassword(AppUser appUser);

    void Delete(int id);

  }
}
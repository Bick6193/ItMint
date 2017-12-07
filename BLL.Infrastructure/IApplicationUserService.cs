using System.Collections.Generic;
using Common.List;
using Domain;
using Domain.Request;
using Domain.User;
using JetBrains.Annotations;

namespace BLL.Infrastructure
{
  public interface IApplicationUserService
  {
    [NotNull]
    [MustUseReturnValue]
    List<UserDTO> List();

    [NotNull]
    [MustUseReturnValue]
    OperationResult<UserDTO> LoginUser([NotNull] string login, [NotNull] string password);

    [CanBeNull]
    [MustUseReturnValue]
    UserDTO FindById(int id);

    [CanBeNull]
    [MustUseReturnValue]
    UserDTO FindByLogin([NotNull] string login);

    [NotNull]
    [MustUseReturnValue]
    void ResetPassword([NotNull] UserDTO request);

    [NotNull]
    [MustUseReturnValue]
    OperationResult RecoverPassword([NotNull] string email);

    [NotNull]
    [MustUseReturnValue]
    OperationResult<bool> ValidateUserName(long userId, [NotNull] string username);


    void CreateUser(UserDTO userDto);

    void UpdateUser(UserDTO userDto);

    void DeleteUser(int id);
  }
}
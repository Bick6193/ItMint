using Common.List;
using Domain;
using Domain.User;
using JetBrains.Annotations;

namespace BLL.Infrastructure
{
    public interface IUserService
    {
        [NotNull]
        [MustUseReturnValue]
        ListResult<UserDisplay> List([NotNull] ListCriteria criteria);

        [NotNull]
        [MustUseReturnValue]
        OperationResult<UserLogin> LoginUser([NotNull] string login, [NotNull] string password);

        [CanBeNull]
        [MustUseReturnValue]
        UserLogin FindByLogin([NotNull] string login);

        [MustUseReturnValue]
        UserDetails GetById(long id);

        [CanBeNull]
        [MustUseReturnValue]
        UserDetails GetByIdLite(long id);

        [MustUseReturnValue]
        UserAdditionalInfo GetAdditionalInfo(long id);

        [NotNull]
        [MustUseReturnValue]
        OperationResult<UserDetails> Upsert([NotNull] UserDetails details);

        [NotNull]
        [MustUseReturnValue]
        OperationResult ResetPassword([NotNull] UserPasswordReset request);

        [NotNull]
        [MustUseReturnValue]
        OperationResult RecoverPassword([NotNull] string email);

        [NotNull]
        [MustUseReturnValue]
        OperationResult<bool> ValidateUserName(long userId, [NotNull] string username);
    }
}
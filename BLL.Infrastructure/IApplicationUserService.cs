using Common.List;
using Domain;
using Domain.User;
using JetBrains.Annotations;

namespace BLL.Infrastructure
{
    public interface IApplicationUserService
    {
        [NotNull]
        [MustUseReturnValue]
        ListResult<ApplicationUserDisplay> List([NotNull] ListCriteria criteria);

        [NotNull]
        [MustUseReturnValue]
        OperationResult<ApplicationUserLogin> LoginUser([NotNull] string login, [NotNull] string password);

        [CanBeNull]
        [MustUseReturnValue]
        ApplicationUserLogin FindByLogin([NotNull] string login);

//        [MustUseReturnValue]
//        UserDetails GetById(long id);
//    
//        [NotNull]
//        [MustUseReturnValue]
//        OperationResult<UserDetails> Upsert([NotNull] UserDetails details);

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
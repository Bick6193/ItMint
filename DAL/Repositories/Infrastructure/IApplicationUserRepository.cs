using Common.List;
using Domain.User;
using JetBrains.Annotations;

namespace DAL.Repositories.Infrastructure
{
    public interface IApplicationUserRepository
    {
        [NotNull]
        [MustUseReturnValue]
        ListResult<ApplicationUserDisplay> List([NotNull] ListCriteria criteria);

        [CanBeNull]
        [MustUseReturnValue]
        ApplicationUserLogin FindByLogin([NotNull] string username);

//        [CanBeNull]
//        [MustUseReturnValue]
//        UserDetails FindByEmail([NotNull] string email);
//
//        [CanBeNull]
//        [MustUseReturnValue]
//        UserDetails FindById(long id);
//
//        [CanBeNull]
//        [MustUseReturnValue]
//        UserDetails GetById(long id);
//
//        [CanBeNull]
//        [MustUseReturnValue]
//        UserDetails GetByIdLite(long id);
//
//        [CanBeNull]
//        [MustUseReturnValue]
//        UserAdditionalInfo GetAdditionalInfo(long id);
//
//        [NotNull]
//        [MustUseReturnValue]
//        UserDetails Upsert([NotNull] UserDetails details);
//
//        [MustUseReturnValue]
//        bool ValidateUserName(long userId, [CanBeNull] string username);
    }
}
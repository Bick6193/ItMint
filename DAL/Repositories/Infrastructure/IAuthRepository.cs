using Domain.Authorization;

namespace DAL.Repositories.Infrastructure
{
    public interface IAuthRepository
    {
        
        ApiClientDetails GetClient(string clientId);
        
        RefreshTokenDetails Upsert(RefreshTokenDetails domain);

        void Delete(string tokenId);
        
        RefreshTokenDetails GetToken(string token);

        RefreshTokenDetails GetTokenByUserAndClient(long userId, string clientId);

        void DeleteUserTokens(long userId);

        void DeleteRoleTokens(long roleId);
    }
}

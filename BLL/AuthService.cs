using BLL.Infrastructure;
using DAL.Repositories.Infrastructure;
using Domain.Authorization;

namespace BLL
{
    public class AuthService : IAuthService
    {
        private IAuthRepository AuthRepository { get; }

        public AuthService(IAuthRepository authRepository)
        {
            AuthRepository = authRepository;
        }

        public ApiClientDetails GetClient(string clientId)
        {
            return AuthRepository.GetClient(clientId);
        }

        public RefreshTokenDetails Upsert(RefreshTokenDetails token)
        {
            return AuthRepository.Upsert(token);
        }

        public void Delete(string refreshTokenId)
        {
            AuthRepository.Delete(refreshTokenId);
        }

        public RefreshTokenDetails GetTokenByRefresh(string refreshToken)
        {
            return AuthRepository.GetToken(refreshToken);
        }

        public RefreshTokenDetails GetTokenByUserAndClient(long userId, string clientId)
        {
            return AuthRepository.GetTokenByUserAndClient(userId, clientId);
        }

        public void DeleteUserTokens(long userId)
        {
            AuthRepository.DeleteUserTokens(userId);
        }

        public void DeleteRoleTokens(long roleId)
        {
            AuthRepository.DeleteRoleTokens(roleId);
        }
    }
}

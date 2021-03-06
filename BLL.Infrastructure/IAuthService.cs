﻿using Domain.Authorization;

namespace BLL.Infrastructure
{
    public interface IAuthService
    {
        ApiClientDetails GetClient(string clientId);
        
        RefreshTokenDetails Upsert(RefreshTokenDetails token);

        void Delete(string refreshTokenId);

        RefreshTokenDetails GetTokenByRefresh(string refreshToken);

        RefreshTokenDetails GetTokenByUserAndClient(long userId, string clientId);

        void DeleteUserTokens(long userId);

        void DeleteRoleTokens(long roleId);
    }
}

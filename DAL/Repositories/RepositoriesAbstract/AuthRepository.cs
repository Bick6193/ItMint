using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DAL.Context;
using DAL.Repositories.Infrastructure;
using Domain.Authorization;
using AutoMapper.QueryableExtensions;
using DAL.Models;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class AuthRepository : BaseRepository, IAuthRepository
  {

    public AuthRepository(ApplicationContext context) : base(context)
    {
    }

    public ApiClientDetails GetClient(string clientId)
    {
      return Mapper.Map<ApiUser, ApiClientDetails>
        (Context.ApiUsers.Single(x=>x.ClientId.Equals(clientId)));
    }

    public RefreshTokenDetails Upsert(RefreshTokenDetails domain)
    {
      var items = (from i in Context.Tokens
                   where i.ClientId == domain.ClientId
                   select i).LastOrDefault();
      if (items != null)
      {
        items.AccessToken = domain.AccessToken;
        items.AccessTokenExpiresUtc = domain.AccessTokenExpiresUtc;
        items.RefreshToken = domain.RefreshToken;
        items.RefreshTokenExpiresUtc = domain.RefreshTokenExpiresUtc;
        items.IssuedUtc = domain.IssuedUtc;
      }
      else
      {
        Context.Tokens.Add(Mapper.Map<RefreshTokenDetails, Token>(domain));
      }
      Context.SaveChanges();
      return null;
    }

    public void Delete(string tokenId)
    {
      throw new NotImplementedException();
    }

    public RefreshTokenDetails GetToken(string token)
    {
      return Mapper.Map<RefreshTokenDetails>(Context.Tokens.FirstOrDefault(x => x.RefreshToken == token));
    }

    public void DeleteUserTokens(long userId)
    {
      throw new NotImplementedException();
    }

    public void DeleteRoleTokens(long roleId)
    {
      throw new NotImplementedException();
    }

    public RefreshTokenDetails GetTokenByUserAndClient(long userId, string clientId)
    {
      return Mapper.Map<Token, RefreshTokenDetails>
        (Context.Tokens.Single(x => x.ClientId.Equals(clientId)
        && x.UserId == userId));
    }
  }
}

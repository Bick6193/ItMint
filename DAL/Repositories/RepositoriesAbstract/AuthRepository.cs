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
      ApiClientDetails client = new ApiClientDetails();
      var items = (from i in Context.ApiUsers where i.ClientId == clientId select i).LastOrDefault();

      client = new ApiClientDetails
      {
        ClientId = items.ClientId,
        Active = items.Active,
        ApplicationType = items.ApplicationType,
        Name = items.Name,
        RefreshTokenLifeTime = (int)items.RefreshTokenLifeTime,
        Secret = items.Secret
      };

      return client;
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
      RefreshTokenDetails token = null;
      var item = from i in Context.Tokens where i.ClientId == clientId && i.UserId == userId select i;
      if (item != null)
      {
        foreach (var coll in item)
        {
          token = new RefreshTokenDetails
          {
            UserId = coll.UserId,
            AccessToken = coll.AccessToken,
            AccessTokenExpiresUtc = coll.AccessTokenExpiresUtc,
            ClientId = coll.ClientId,
            IssuedUtc = coll.IssuedUtc,
            RefreshToken = coll.RefreshToken,
            RefreshTokenExpiresUtc = coll.RefreshTokenExpiresUtc
          };
        }

      }
      return token;
    }
  }
}

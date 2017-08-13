using System;
using System.Collections.Generic;
using BLL.Infrastructure;
using Common.List;
using DAL.Repositories.Infrastructure;
using Domain;
using Domain.User;
using JetBrains.Annotations;

namespace BLL
{
    [UsedImplicitly]
    public class ApplicationUserService : IApplicationUserService
    {
      private IApplicationUserRepository Repository { get; }
      
      private ITransactionManager TransactionManager { get; }

      public ApplicationUserService(IApplicationUserRepository repository, ITransactionManager transactionManager)
      {
        Repository = repository;
        TransactionManager = transactionManager;
      }
      public ListResult<ApplicationUserDisplay> List(ListCriteria criteria)
      {
        throw new NotImplementedException();
      }

      public OperationResult<ApplicationUserLogin> LoginUser(string login, string password)
      {
        var user = Repository.FindByLogin(login);

        if (user == null)
        {
          return new OperationResult<ApplicationUserLogin>()
          {
            Success = false,
            Messages = new List<string>() { "Invalid username or password" },
            Code = OperationCode.AuthenticationInvalidCredentials
          };
        }

        if (user.Password != password)
        {
          return new OperationResult<ApplicationUserLogin>
          {
            Success = false,
            Messages = new List<string>(){ "Couldn't log you in. Please try again!" },
            Code = OperationCode.AuthenticationInvalidCredentials
          };
        }

        if (!user.Active)
        {
          return new OperationResult<ApplicationUserLogin>
          {
            Success = false,
            Messages = new List<string>() { "You account is not active. Please contact administrator." },
            Code = OperationCode.AuthenticationInvalidCredentials
          };
        }

        return new OperationResult<ApplicationUserLogin> { Object = user };
    }

      public ApplicationUserLogin FindByLogin(string login)
      {
        throw new NotImplementedException();
      }

      public OperationResult ResetPassword(UserPasswordReset request)
      {
        throw new NotImplementedException();
      }

      public OperationResult RecoverPassword(string email)
      {
        throw new NotImplementedException();
      }

      public OperationResult<bool> ValidateUserName(long userId, string username)
      {
        throw new NotImplementedException();
      }
    }
}
using System;
using System.Collections.Generic;
using BLL.Infrastructure;
using Common.List;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain;
using Domain.RegistrationMailData;
using Domain.Request;
using Domain.User;
using JetBrains.Annotations;

namespace BLL
{
  [UsedImplicitly]
  public class ApplicationUserService : IApplicationUserService
  {
    private IApplicationUserRepository Repository { get; }

    private ITransactionManager TransactionManager { get; }

    private ISetPasswordIdentity setPasswordIdentity { get; }

    private readonly string Message = "Hello, " + Environment.NewLine +
                                   "Please, click to the link to set your password for ItMint Admin part:" +
                                   "LINK: http://localhost:4200/Reset/";

    public ApplicationUserService(IApplicationUserRepository repository,
      ITransactionManager transactionManager,
      ISetPasswordIdentity passwordIdentity)
    {
      Repository = repository;
      TransactionManager = transactionManager;
      setPasswordIdentity = passwordIdentity;
    }
    public List<UserDTO> List()
    {
      return Repository.GetAll();
    }

    public UserDTO FindById(int id)
    {
      return Repository.GetById(id);
    }

    public OperationResult<UserDTO> LoginUser(string login, string password)
    {
      var user = Repository.FindByLogin(login);

      if (user == null)
      {
        return new OperationResult<UserDTO>()
        {
          Success = false,
          Message = "Invalid username or password",
          Code = OperationCode.AuthenticationInvalidCredentials
        };
      }

      if (user.Password != password)
      {
        return new OperationResult<UserDTO>
        {
          Success = false,
          Message = "Couldn't log you in. Please try again!",
          Code = OperationCode.AuthenticationInvalidCredentials
        };
      }

      if (!user.Active)
      {
        return new OperationResult<UserDTO>
        {
          Success = false,
          Message = "You account is not active. Please contact administrator.",
          Code = OperationCode.AuthenticationInvalidCredentials
        };
      }

      return new OperationResult<UserDTO> { Object = user };
    }

    public void CreateUser(UserDTO userDto)
    {
      Repository.Create(AutoMapper.Mapper.Map<UserDTO, AppUser>(userDto));
      EmailModel emailModel = new EmailModel
      {
        Id = Repository.ReturnId(AutoMapper.Mapper.Map<UserDTO, AppUser>(userDto)),
        FullName = userDto.FullName,
        EmailFor = userDto.Email
      };
      setPasswordIdentity.SendEmailRuntime(emailModel, Message + emailModel.Id);
    }

    public void UpdateUser(UserDTO userDto)
    {
      Repository.Update(AutoMapper.Mapper.Map<UserDTO, AppUser>(userDto));
    }

    public void DeleteUser(int id)
    {
      Repository.Delete(id);
    }
    public UserDTO FindByLogin(string login)
    {
      throw new NotImplementedException();
    }

    public void ResetPassword(UserDTO request)
    {
      AppUser user = new AppUser
      {
        Password = request.Password,
        Id = request.Id
      };
      Repository.UpdatePassword(user);
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
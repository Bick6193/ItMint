﻿using System;
using System.Collections.Generic;
using BLL.Infrastructure.RequestSignature;
using AutoMapper;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using DAL.Repositories.RepositoriesAbstract;
using Domain.RegistrationMailData;
using Domain.Request;

namespace BLL.Request
{
  public class RequestGetService : IRequestGetService
  {
    private IRequestRepository Repository { get;}
    private ISetPasswordIdentity setPasswordIdentity { get; }

    private readonly string Message = "New Request";

    public RequestGetService(IRequestRepository repository, ISetPasswordIdentity passwordIdentity)
    {
      Repository = repository;
      setPasswordIdentity = passwordIdentity;
    }

    public IEnumerable<RequestDTO> GetAllRequests()
    {
      return Repository.GetAll();
    }

    public RequestDTO GetRequestById(int id)
    {
      return Repository.GetById(id);
    }

    public IEnumerable<RequestDTO> BasicSearch(string line)
    {
      InboxPanelService panel = new InboxPanelService();
      panel.SearchDataContainer.SearchTerm = line;
      return Repository.BasicSearch(panel);
    }

    public DataRequestServices CountRequests()
    {
      return Repository.CountRequests();
    }

    public void MakeRequest(RequestDTO requestDto)
    {
      DAL.Models.Request request = new DAL.Models.Request
      {
        Name = requestDto.Name,
        Date = DateTime.Now,
        Description = requestDto.Description, 
        Email = requestDto.Email,
        Phone = requestDto.Phone,
        RequestTypeInString = requestDto.RequestTypeInString,
        RequestTypeId = null,
        UserId = requestDto.UserId,
        Viewed = false
      };
      Repository.Insert(request);
      EmailModel emailModel = new EmailModel
      {
        EmailFor = "nikita.sviridovich@itmint.ca",
        FullName = requestDto.Name
      };
      setPasswordIdentity.SendEmailRuntime(emailModel, Message);
    }

    public void GetFlag(int id)
    {
      Repository.GetFlag(id);
    }

    public void Delete(int id)
    {
      Repository.Delete(id);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.Mappers;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.Request;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class RequestTypesRepository : IRequestTypesRepository
  {
    private ApplicationContext ApplicationContext { get; }

    public RequestTypesRepository(ApplicationContext context)
    {
      ApplicationContext = context;
    }

    public IEnumerable<RequestTypeDTO> GetAll()
    {
      return AutoMapper.Mapper.Map<List<RequestTypeDTO>>(ApplicationContext.RequestsType);
    }

    public RequestType GetById(int id)
    {
      return ApplicationContext.RequestsType.Single(x => x.Id == id);
    }

    public IEnumerable<string> GetStringTypes()
    {
      return ApplicationContext.RequestsType.Select(x => x.Type);
    }

    public int GetCountsTypes(string type)
    {
      int counts = (from i in ApplicationContext.Requests where i.RequestTypeInString.Equals(type) select i).Count();
      return counts;
    }

    public void Insert(RequestType requestType)
    {
      ApplicationContext.RequestsType.Add(requestType);
      ApplicationContext.SaveChanges();
    }

    public void Update(RequestType requestType)
    {
      var item = (from i in ApplicationContext.RequestsType where i.Id == requestType.Id select i).LastOrDefault();
      #region dontSeeIt
      item.Color = requestType.Color;
      item.EmployeesEmail = requestType.EmployeesEmail;
      item.EmployeesName = requestType.EmployeesName;
      item.IsDefault = requestType.IsDefault;
      item.IsEnabled = requestType.IsEnabled;
      item.MessageBodyToCustomer = requestType.MessageBodyToCustomer;
      item.MessageToCustomer = requestType.MessageToCustomer;
      item.Type = requestType.Type;

      #endregion
      ApplicationContext.RequestsType.Update(item);
      ApplicationContext.SaveChanges();
    }
  }
}

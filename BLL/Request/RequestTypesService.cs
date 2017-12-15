using System;
using System.Collections.Generic;
using System.Text;
using BLL.Infrastructure.RequestSignature;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.Request;

namespace BLL.Request
{
  public class RequestTypesService : IRequestTypesService
  {
    private IRequestTypesRepository requestTypesRepository { get; }


    public RequestTypesService(IRequestTypesRepository typesRepository)
    {
      requestTypesRepository = typesRepository;
    }

    public IEnumerable<RequestTypeDTO> GetAll()
    {
      return requestTypesRepository.GetAll();
    }

    public RequestTypeDTO GetById(int id)
    {
      return AutoMapper.Mapper.Map<RequestTypeDTO>(requestTypesRepository.GetById(id));
    }

    public IEnumerable<string> GetStringTypes()
    {
      return requestTypesRepository.GetStringTypes();
    }

    public int GetCountsTypes(string type)
    {
      return requestTypesRepository.GetCountsTypes(type);
    }

    public void Insert(RequestTypeDTO requestTypeDto) //send emails
    {
      RequestType requestType = new RequestType //Add another values IMPORTANT!
      {
        EmployeesName = requestTypeDto.EmployeesName,
        EmployeesEmail = requestTypeDto.EmployeesEmail,
        IsDefault = requestTypeDto.IsDefault,
        IsEnabled = requestTypeDto.IsEnabled,
        MessageBodyToCustomer = requestTypeDto.MessageBodyToCustomer,
        MessageToCustomer = requestTypeDto.MessageToCustomer,
        Color = requestTypeDto.Color,
        Type = requestTypeDto.Type
      };
      requestTypesRepository.Insert(requestType);

    }

    public void Update(RequestTypeDTO requestTypeDto)
    {
      RequestType requestType = new RequestType //Add another values IMPORTANT!
      {
        Id = requestTypeDto.Id,
        EmployeesName = requestTypeDto.EmployeesName,
        EmployeesEmail = requestTypeDto.EmployeesEmail,
        IsDefault = requestTypeDto.IsDefault,
        IsEnabled = requestTypeDto.IsEnabled,
        MessageBodyToCustomer = requestTypeDto.MessageBodyToCustomer,
        MessageToCustomer = requestTypeDto.MessageToCustomer,
        Color = requestTypeDto.Color,
        Type = requestTypeDto.Type
      };
      requestTypesRepository.Update(requestType);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Domain.Request;

namespace DAL.Repositories.Infrastructure
{
  public interface IRequestTypesRepository
  {
    IEnumerable<RequestTypeDTO> GetAll();

    IEnumerable<string> GetStringTypes();

    RequestType GetById(int id);

    int GetCountsTypes(string type);

    void Insert(RequestType requestType);
  }
}

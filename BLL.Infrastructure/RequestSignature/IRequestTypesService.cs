using System;
using System.Collections.Generic;
using System.Text;
using Domain.Request;

namespace BLL.Infrastructure.RequestSignature
{
  public interface IRequestTypesService
  {
    IEnumerable<RequestTypeDTO> GetAll();

    IEnumerable<string> GetStringTypes();

    int GetCountsTypes(string type);

    void Insert(RequestTypeDTO requestTypeDto);
  }
}

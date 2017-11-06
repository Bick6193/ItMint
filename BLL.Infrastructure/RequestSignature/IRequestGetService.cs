using System;
using System.Collections.Generic;
using System.Text;
using BLL.Infrastructure.DTO;
using DAL.Models;
namespace BLL.Infrastructure.RequestSignature
{
  public interface IRequestGetService
  {
    IEnumerable<RequestDTO> GetAllRequests();

    RequestDTO GetRequestById(int? id);

    void MakeRequest(RequestDTO request);
  }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Domain.Request;

namespace BLL.Infrastructure.RequestSignature
{
  public interface IRequestGetService
  {
    IEnumerable<RequestDTO> GetAllRequests();

    RequestDTO GetRequestById(int id);

    IEnumerable<RequestDTO> BasicSearch(string line);

    DataRequestServices CountRequests();

    void MakeRequest(RequestDTO request);

    void GetFlag(int id);

    void Delete(int id);
  }
}

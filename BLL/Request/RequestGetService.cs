using System;
using System.Collections.Generic;
using BLL.Infrastructure.DTO;
using BLL.Infrastructure.RequestSignature;
using AutoMapper;
using DAL.UnitOfWork;

namespace BLL.Request
{
  public class RequestGetService : IRequestGetService
  {
    private IUnitOfWork Database { get; set; }

    public RequestGetService(IUnitOfWork tempUOF)
    {
      Database = tempUOF;
    }

    public IEnumerable<RequestDTO> GetAllRequests()
    {
      Mapper.Initialize(cfg=>cfg.CreateMap<DAL.Models.Request, RequestDTO>());
      return Mapper.Map<IEnumerable<DAL.Models.Request>, List<RequestDTO>>(Database.Requests.GetAll());
    }

    public RequestDTO GetRequestById(int? id)
    {
      throw new NotImplementedException();
    }

    public void MakeRequest(RequestDTO request)
    {
      throw new NotImplementedException();
    }
  }
}

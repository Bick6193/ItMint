using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Infrastructure.DTO;
using BLL.Infrastructure.RequestSignature;
using BLL.Request;
using DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using Web.Models;

namespace Web.Controllers
{
  [Produces("application/json")]
  [Route("api/Request")]
  public class RequestController : Controller
  {
    IRequestGetService requestGetService;

    public RequestController(IRequestGetService request)
    {
      requestGetService = request;
    }
  
    [HttpGet("RequestToInbox")]
    public IEnumerable<RequestViewModel> GetRequestToInbox()
    {
      IEnumerable<RequestDTO> requestDtos = requestGetService.GetAllRequests();
      Mapper.Initialize(cfg=>cfg.CreateMap<RequestDTO, RequestViewModel>());
      IEnumerable<RequestViewModel> requests = Mapper.Map<IEnumerable<RequestDTO>, List<RequestViewModel>> (requestDtos);
      return requests;
    }

    [HttpPost("Form")]
    public RequestViewModel RequestFromClientForm([FromForm] RequestViewModel request)
    {
      return null;
    }
    [HttpPost("Form/Doc")]
    public IActionResult RequestFromClientFormDoc([FromForm] File file)
    {
      return null;
    }
  }
}

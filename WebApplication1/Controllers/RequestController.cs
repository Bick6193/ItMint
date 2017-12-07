using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Infrastructure.RequestSignature;
using BLL.Request;
using DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using Domain;
using Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Web.Models;

namespace Web.Controllers
{
  
  [Route("api/Request")]
  public class RequestController : Controller
  {
    IRequestGetService requestGetService;
    IFileService fileService;
    IRequestTypesService requestTypesService;

    public RequestController(IRequestGetService request,
                             IFileService file,
                             IRequestTypesService typesService)
    {
      requestGetService = request;
      fileService = file;
      requestTypesService = typesService;
    }
    [HttpPost("Form")]
    public IActionResult RequestFromClientForm([FromForm]RequestDTO requestForm)
    {
      requestGetService.MakeRequest(requestForm);
      return Ok(new {temp = true});
    }
    [Authorize]
    [HttpGet("RequestToInbox")]
    public IEnumerable<RequestDTO> GetRequestToInbox()
    {
      var user = ControllerContext.HttpContext.User.Identity.IsAuthenticated;
      IEnumerable<RequestDTO> requestDtos = requestGetService.GetAllRequests();
      return requestDtos;
    }
    [Authorize]
    [HttpPost("RequestIdToInbox")]
    public RequestDTO GetRequestToInboxById(int id)
    {
      RequestDTO requestDtos = requestGetService.GetRequestById(id);
      return requestDtos;
    }
    [Authorize]
    [HttpPost("RequestSearchToInbox")]
    public IEnumerable<RequestDTO> GetSearchData(string line)
    {
      IEnumerable<RequestDTO> requestDto = requestGetService.BasicSearch(line);
      return requestDto;
    }
    [Authorize]
    [HttpPost("RequestFlagToInbox")]
    public bool GetFlag(int id)
    {
      requestGetService.GetFlag(id);
      return true;
    }
    [Authorize]
    [HttpGet("RequestToInboxInfo")]
    public DataRequestServices GetInboxInformation()
    {
      return requestGetService.CountRequests();
    }
    [Authorize]
    [HttpPost("Delete")]
    public IActionResult DeleteRequest(int id)
    {
      requestGetService.Delete(id);
      return Ok(new { temp = true });
    }

    [HttpPost("Doc")]
    public async Task<IActionResult> RequestFromClientFormDoc()
    {

      FullRequestForm fullRequestForm = new FullRequestForm(Request);

      if (ModelState.IsValid)
      {
        int? count = 1;
        if (fullRequestForm.Files.Count > 5)
        {
          return null;
        }
        foreach (var items in fullRequestForm.Files)
        {
          if (items != null && items.Length > 0)
          {
            using (var reader = new System.IO.BinaryReader(items.OpenReadStream()))
            {
              var binData = new BinaryDataDTO
              {
                Content = reader.ReadBytes(Convert.ToInt32(items.Length))
              };
              var fileVm = new FileDTO
              {
                BinaryData = binData,
                FileName = Path.GetFileName(items.FileName),
                ContentType = items.ContentType,
                RequestFormToken = fullRequestForm.Token,
                FileIndex = count++
              };
              fileService.AddFile(fileVm);
            }
          }
        }
      }
      return Ok(new { count = fullRequestForm.Files.Count });
    }

    [HttpPost("Files")]
    public IEnumerable<FileDTO> GetFiles(int id)
    {
      return fileService.GetById(id);
    }
    [HttpGet("Types")]
    public IEnumerable<string> GetTypes()
    {
      return requestTypesService.GetStringTypes();
    }
  }
}

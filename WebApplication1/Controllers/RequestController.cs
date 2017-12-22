using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json.Linq;
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

    private static readonly HttpClient client = new HttpClient();

    [HttpPost]
    [Route("Form")]
    public async Task<IActionResult> RequestFromClientForm([FromForm] RequestDTO requestForm)
    {

      IpGeographicLocation model = null;
      //On Deploy change this!!!
      //var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
      var RequestLocation = "134.17.27.99";
      if (!string.IsNullOrEmpty(RequestLocation))
      {
        model = await IpGeographicLocation.QueryGeographicalLocationAsync(RequestLocation);
      }
      requestForm.Country = model.City;
      //requestGetService.MakeRequest(requestForm);
      return Ok(new { temp = true });
    }

    [Authorize]
    [HttpGet]
    [Route("RequestToInbox")]
    public IEnumerable<RequestDTO> GetRequestToInbox()
    {
      var user = ControllerContext.HttpContext.User.Identity.IsAuthenticated;
      IEnumerable<RequestDTO> requestDtos = requestGetService.GetAllRequests();
      return requestDtos;
    }

    [Authorize]
    [HttpPost]
    [Route("RequestIdToInbox")]
    public RequestDTO GetRequestToInboxById(int id)
    {
      RequestDTO requestDtos = requestGetService.GetRequestById(id);
      return requestDtos;
    }

    [Authorize]
    [HttpPost]
    [Route("RequestSearchToInbox")]
    public IEnumerable<RequestDTO> GetSearchData(string line)
    {
      IEnumerable<RequestDTO> requestDto = requestGetService.BasicSearch(line);
      return requestDto;
    }

    [Authorize]
    [HttpPost]
    [Route("RequestFlagToInbox")]
    public bool GetFlag(int id)
    {
      requestGetService.GetFlag(id);
      return true;
    }

    [Authorize]
    [HttpGet]
    [Route("RequestToInboxInfo")]
    public DataRequestServices GetInboxInformation()
    {
      return requestGetService.CountRequests();
    }

    [Authorize]
    [HttpPost]
    [Route("Delete")]
    public IActionResult DeleteRequest(int id)
    {
      requestGetService.Delete(id);
      return Ok(new { temp = true });
    }

    [HttpPost]
    [Route("Doc")]
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

    [HttpPost]
    [Route("GetFileFromByte")]
    public IFormFile GetFileFromByte([FromBody] DownloadFileViewModel downloadFile)
    {
      var file = fileService.DownloadById(downloadFile.IdRequest, downloadFile.IdFile);
      try
      {
        using (var fileStream = new FileStream(downloadFile.FileName, FileMode.Create, FileAccess.Write))
        {
          fileStream.Write(file.Content, 0, file.Content.Length);
        }
      }
      catch (Exception e)
      {
        OperationResult.FromException(e, 0);
      }
      return null;
    }

    [HttpPost]
    [Route("Files")]
    public IEnumerable<FileDTO> GetFiles(int id)
    {
      return fileService.GetById(id);
    }

    [HttpGet]
    [Route("RequestConfig")]
    public RequestConfiguration GetTypes()
    {
      var types = requestTypesService.GetStringTypes();
      RequestConfiguration requestConfiguration = new RequestConfiguration
      {
        Types = types,
        Location = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()
      };
      return requestConfiguration;
    }
  }
}


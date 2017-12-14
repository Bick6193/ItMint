using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Infrastructure.RequestSignature;
using Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
  [Route("api/Users")]
  public class UsersController : Controller
  {
    IApplicationUserService applicationUserService;

    IRequestTypesService requestTypesService;

    public UsersController(IApplicationUserService userService,
      IRequestTypesService requestTypes,
      IRequestGetService getService)
    {
      applicationUserService = userService;
      requestTypesService = requestTypes;
    }

    [HttpPost]
    [Route("RequestUser")]
    public IActionResult RequestUser([FromBody]UserDTO userDto)
    {
      applicationUserService.CreateUser(userDto);
      return Ok(new {temp = true});
    }
    [HttpPost]
    [Route("UpdateUser")]
    public IActionResult UpdateUser([FromBody] UserDTO userDto)
    {
      applicationUserService.UpdateUser(userDto);
      return Ok(new { temp = true });
    }
    [HttpPost]
    [Route("DeleteUser")]
    public void DeleteUser(int id)
    {
      applicationUserService.DeleteUser(id);
    }
    [HttpPost]
    [Route("SetPassword")]
    public IActionResult SetPassword([FromBody] UserDTO userDto)
    {
      applicationUserService.ResetPassword(userDto);
      return Ok(new { temp = true }); 
    }

    [HttpGet]
    [Route("GetUsersSettings")]
    public List<UserDTO> GetToSettings()
    {
      return applicationUserService.List(); 
    }
    [HttpPost]
    [Route("GetUser")]
    public UserDTO GetById(int id)
    {
      return applicationUserService.FindById(id);
    }
    [HttpPost]
    [Route("SaveRequest")]
    public IActionResult SaveRequest([FromBody] RequestTypeDTO requestTypeDto)
    {
      requestTypesService.Insert(requestTypeDto);
      return Ok(new { temp = true });
    }
    [HttpGet]
    [Route("GetRequestTypes")]
    public List<RequestTypesViewModel> RequestTypes()
    {
      RequestTypesViewModel requestTypesModel;
      List<RequestTypesViewModel> requestTypesViewModel = new List<RequestTypesViewModel>();
      var items = requestTypesService.GetAll();

      foreach (var collection in items)
      {
        var counts = requestTypesService.GetCountsTypes(collection.Type);
        requestTypesModel = new RequestTypesViewModel
        {
          Id = collection.Id,
          EmployeesEmail = collection.EmployeesEmail,
          Type = collection.Type,
          IsDefault = collection.IsDefault,
          IsEnabled = collection.IsEnabled,
          Color = collection.Color,
          Count = counts
        };
        requestTypesViewModel.Add(requestTypesModel);
      }
      return requestTypesViewModel;
    }

    [HttpPost]
    [Route("GetRequest")]
    public RequestTypeDTO GetTypeById(int id)
    {
      return requestTypesService.GetById(id);
    }
  }
}

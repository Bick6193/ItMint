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

    [HttpPost("RequestUser")]
    public void RequestUser([FromBody]UserDTO userDto)
    {
      applicationUserService.CreateUser(userDto);
    }
    [HttpPost("UpdateUser")]
    public void UpdateUser([FromBody] UserDTO userDto)
    {
      applicationUserService.UpdateUser(userDto);
    }
    [HttpPost("DeleteUser")]
    public void DeleteUser(int id)
    {
      applicationUserService.DeleteUser(id);
    }
    [HttpPost("SetPassword")]
    public IActionResult SetPassword([FromBody] UserDTO userDto)
    {
      applicationUserService.ResetPassword(userDto);
      return Ok(new { temp = true }); 
    }

    [HttpGet("GetUsersSettings")]
    public List<UserDTO> GetToSettings()
    {
      return applicationUserService.List(); 
    }
    [HttpPost("GetUser")]
    public UserDTO GetById(int id)
    {
      return applicationUserService.FindById(id);
    }
    [HttpPost("SaveRequest")]
    public IActionResult SaveRequest([FromBody] RequestTypeDTO requestTypeDto)
    {
      requestTypesService.Insert(requestTypeDto);
      return Ok(new { temp = true });
    }
    [HttpGet("GetRequestTypes")]
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
  }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
 // [Authorize(Roles = "MyRole!!")]
  [Authorize]
  [Produces("application/json")]
  [Route("api/Values")]
  public class ValuesController : Controller
  {
    [HttpGet]
    public IEnumerable<string> Get()
    {
      var user = ControllerContext.HttpContext.User;
      return new string[] {"Hello", "World", "World test2" };
    }
  }
}
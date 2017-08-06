﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
  [Produces("application/json")]
  [Route("api/Values")]
  public class ValuesController : Controller
  {
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] {"Hello", "World", "World test2" };
    }
  }
}
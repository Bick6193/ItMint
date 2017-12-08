using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
  [Produces("application/json")]
  [Route("api/Metadata")]
  public class MetadataController : Controller
  {

    public MetadataController()
    {
      
    }
    [HttpPost]
    [Route("Insert")]
    public IActionResult SaveMetadata([FromBody]MetadataDTO metadataDto)
    {
      return Ok(new {temp = true});
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Infrastructure.RequestSignature;

namespace Web.Controllers
{
  [Produces("application/json")]
  [Route("api/Inbox")]
  public class InboxController : Controller
  {
    IRequestGetService requestGetService;

    public InboxController(IRequestGetService request)
    {
      requestGetService = request;
    }
    [HttpPost]
    [Route("Delete")]
    public void DeleteRequest(int id)
    {
      
    }
  }
}

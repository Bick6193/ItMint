using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Request;
using Microsoft.AspNetCore.Http;

namespace Web.Models
{
  public class FullRequestForm
  {
   // public RequestDTO RequestDto { get; set; }
    //public string RequestDto { get; set; }
    public List<IFormFile> Files { get; set; }
    public string Token { get; set; }

    public FullRequestForm(HttpRequest request)
    {
      var form = request.Form;

      Files = new List<IFormFile>(form.Files);
      Token = form.Keys.LastOrDefault();
    }

  }
}

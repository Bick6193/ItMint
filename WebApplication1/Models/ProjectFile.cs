using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Models
{
  public class ProjectFile
  {
    public IFormFile File { get; set; }

    public ProjectFile(HttpRequest request)
    {
      var form = request.Form;
      File = form.Files[1];
    }

  }
}

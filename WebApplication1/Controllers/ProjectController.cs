using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
  [Produces("application/json")]
  [Route("api/Project")]
  public class ProjectController : Controller
  {
    private IProjectService projectService { get; }

    public ProjectController(IProjectService service)
    {
      projectService = service;
    }
    [HttpGet]
    [Route("GetProjects")]
    public IEnumerable<ProjectDTO> GetProjects()
    {

      return projectService.GetProjects();
    }
    [HttpPost]
    [Route("Insert")]
    public IActionResult InsertProject([FromBody] ProjectDTO project)
    {
      projectService.Insert(project);
      return Ok();
    }
    [HttpPost]
    [Route("Doc")]
    public async Task<IActionResult> GetFile()
    {
      IFormFile file = Request.Form.Files.FirstOrDefault();
      string name = Request.Form.Keys.LastOrDefault();
      if (file != null && file.Length != 0)
      {
        projectService.GetArchive(file, name);

      }
      return Ok(new { count = true });
    }

  }
}

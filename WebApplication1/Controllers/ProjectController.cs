using System;
using System.Collections.Generic;
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
      FullRequestForm file = new FullRequestForm(Request);
      return Ok(new { count = true });
    }

  }
} 

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
    [Route("GetProjectById")]
    public ProjectDTO GetProjectById(string id)
    {
      return projectService.GetProjectById(id);
    }

    [HttpPost]
    [Route("GetFilesById")]
    public ProjectFileDTO GetFileById(string id)
    {
      return projectService.GetFileById(id);
    }
    [HttpPost]
    [Route("GetDatesById")]
    public List<DateTime> GetDatesById(string id)
    {
      return projectService.GetDatesById(id);
    }
    [HttpPost]
    [Route("GetDataByDate")]
    public ProjectDTO GetDataByDate([FromBody]DateProject dateProject)
    {
      return projectService.GetDataByDate(dateProject.DateTime, dateProject.Id);
    }
    [HttpPost]
    [Route("GetFilesByDate")]
    public ProjectFileDTO GetFileByDate([FromBody] DateProject dateProject)
    {
      return projectService.GetFileByDate(dateProject.DateTime, dateProject.Id);
    }
    [HttpPost]
    [Route("Insert")]
    public IActionResult InsertProject([FromBody] ProjectDTO project)
    {
      projectService.Insert(project);
      return Ok(new { temp = true });
    }
    [HttpPost]
    [Route("DeleteProject")]
    public IActionResult DeleteProject(string id)
    {
      projectService.Delete(id);
      return Ok(new { temp = true });
    }
    [HttpPost]
    [Route("Doc")]
    public async Task<IActionResult> GetFile()
    {
      IFormFile file = Request.Form.Files.FirstOrDefault();
      string name = Request.Form.Keys.FirstOrDefault();
      string id = Request.Form.Keys.LastOrDefault();
      if (file != null && file.Length != 0)
      {
        projectService.GetArchive(file, name, id);

      }
      return Ok(new { count = true });
    }

  }
}

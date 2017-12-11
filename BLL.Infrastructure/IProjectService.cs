using System;
using System.Collections.Generic;
using System.Text;
using Domain.Request;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace BLL.Infrastructure
{
  public interface IProjectService
  {
    IEnumerable<ProjectDTO> GetProjects();

    void GetArchive(IFormFile file, string name);

    void Insert(ProjectDTO projectDto);
  }
}

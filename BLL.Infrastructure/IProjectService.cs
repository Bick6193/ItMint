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

    ProjectDTO GetProjectById(string id);

    ProjectDTO GetDataByDate(DateTime date, string id);

    ProjectFileDTO GetFileById(string id);

    List<DateTime> GetDatesById(string id);

    ProjectFileDTO GetFileByDate(DateTime date, string id);

    void GetArchive(IFormFile file, string name, string id);

    void Insert(ProjectDTO projectDto);

    void Delete(string id);
  }
}

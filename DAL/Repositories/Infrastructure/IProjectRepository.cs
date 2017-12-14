using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Repositories.Infrastructure
{
  public interface IProjectRepository
  {

    IEnumerable<Projects> GetProjects();

    Projects GetProjectById(string id);

    ProjectFile GetFilesById(string id);

    Projects GetDataByDate(DateTime date, string id);

    List<DateTime> GetDatesById(string id);

    ProjectFile GetFilesByDate(DateTime date, string id);

    void Insert(Projects projects);

    void InsertFile(ProjectFile project);

    void Delete(string id);
  }
}

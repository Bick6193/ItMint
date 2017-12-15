using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class ProjectRepository : IProjectRepository
  {

    private ApplicationContext ApplicationContext { get; }

    public ProjectRepository(ApplicationContext context)
    {
      ApplicationContext = context;
    }

    public IEnumerable<Projects> GetProjects()
    {
      return AutoMapper.Mapper.Map<List<Projects>>(ApplicationContext.Projectses.GroupBy(x => x.Name).Select(y => y.Last()));
    }

    public Projects GetProjectById(string id)
    {
      return ApplicationContext.Projectses.Where(x => x.ProjectId.Equals(id)).LastOrDefault();
    }

    public ProjectFile GetFilesById(string id)
    {
      ProjectFile item = (from i in ApplicationContext.ProjectFiles where i.ProjectId == id select i).LastOrDefault();
      return item;
    }

    public List<DateTime> GetDatesById(string id)
    {
      List<DateTime> datesList = new List<DateTime>();
      var dates = ApplicationContext.Projectses.Where(x => x.ProjectId.Equals(id)).Select(y => y.RevisionTime).OrderByDescending(x => x);
      foreach (var collection in dates)
      {
        datesList.Add(collection);
      }
      return datesList;
    }

    public Projects GetDataByDate(DateTime date, string id)
    {
      return ApplicationContext.Projectses.Single(x => x.RevisionTime.Date == date.Date && x.RevisionTime.Second == date.Second && x.ProjectId.Equals(id));
    }

    public ProjectFile GetFilesByDate(DateTime date, string id)
    {
      try
      {
        return ApplicationContext.ProjectFiles.Single(x => x.RevisionTime.Date == date.Date
        && x.RevisionTime.Second == date.Second
        && x.RevisionTime.Hour == date.Hour
        && x.ProjectId.Equals(id));
      }
      catch (Exception e)
      {
        return null;
      }
      
    }
    public void Insert(Projects projects)
    {
      ApplicationContext.Projectses.Add(projects);
      ApplicationContext.SaveChanges();
    }

    public void InsertFile(ProjectFile project)
    {
      project.RevisionTime = DateTime.Now;
      ApplicationContext.ProjectFiles.Add(project);
      ApplicationContext.SaveChanges();
    }

    public void Delete(string id)
    {
      var items = ApplicationContext.Projectses.Where(x => x.ProjectId.Equals(id));
      foreach (var collection in items)
      {
        ApplicationContext.Projectses.Remove(collection);
      }
      ApplicationContext.SaveChanges();
    }


  }
}

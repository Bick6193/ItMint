using System;
using System.Collections.Generic;
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
      return AutoMapper.Mapper.Map<List<Projects>>(ApplicationContext.Projectses);
    }

    public void Insert(Projects projects)
    {
      ApplicationContext.Projectses.Add(projects);
      ApplicationContext.SaveChanges();
    }
  }
}

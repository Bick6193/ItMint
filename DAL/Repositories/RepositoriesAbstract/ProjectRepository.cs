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

    public void Insert(Projects projects)
    {
      ApplicationContext.Projectses.Add(projects);
      ApplicationContext.SaveChanges();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Repositories.Infrastructure
{
  public interface IProjectRepository
  {

    void Insert(Projects projects);

  }
}

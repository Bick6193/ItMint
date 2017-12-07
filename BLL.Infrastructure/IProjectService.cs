using System;
using System.Collections.Generic;
using System.Text;
using Domain.Request;

namespace BLL.Infrastructure
{
  public interface IProjectService
  {
    void Insert(ProjectDTO projectDto);
  }
}

using System;
using System.Collections.Generic;
using System.Text;
using BLL.Infrastructure;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.Request;

namespace BLL
{
  public class ProjectService : IProjectService
  {
    private IProjectRepository ProjectRepository { get; }

    public ProjectService(IProjectRepository projectRepository)
    {
      ProjectRepository = projectRepository;
    }


    public void Insert(ProjectDTO projectDto)
    {
      ProjectRepository.Insert(AutoMapper.Mapper.Map<ProjectDTO, Projects>(projectDto));
    }
  }
}

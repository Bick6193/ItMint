using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using BLL.Infrastructure;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain;
using Domain.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BLL
{
  public class ProjectService : IProjectService
  {
    private IHostingEnvironment hostingEnvironment { get; }

    private IProjectRepository ProjectRepository { get; }

    private IFolderVersion folderVersion { get; }

    public ProjectService(IProjectRepository projectRepository,
      IHostingEnvironment environment,
      IFolderVersion version)
    {
      ProjectRepository = projectRepository;
      hostingEnvironment = environment;
      folderVersion = version;
    }

    public IEnumerable<ProjectDTO> GetProjects()
    {
      return AutoMapper.Mapper.Map<List<ProjectDTO>>(ProjectRepository.GetProjects());
    }

    public void GetArchive(IFormFile file, string name)
    {
      //using (var stream = file.OpenReadStream())
      //using (var archive = new ZipArchive(stream))
      //{
      //  var fileNameCollection = archive.Entries;
      //}

      var uploads = Path.Combine(hostingEnvironment.ContentRootPath + "\\" + name,
        folderVersion.GetFolderVersion(hostingEnvironment.ContentRootPath + "\\" + name)); //Change to WebRootPath
      var pathFile = Path.Combine(uploads, file.FileName);
      using (var fileStream = new FileStream(pathFile, FileMode.Create))
      {
        file.CopyTo(fileStream);
      }

    }
    public void Insert(ProjectDTO projectDto)
    {
      ProjectRepository.Insert(AutoMapper.Mapper.Map<ProjectDTO, Projects>(projectDto));
    }
  }
}

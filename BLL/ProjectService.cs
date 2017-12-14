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

    const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

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



    public void GetArchive(IFormFile file, string name, string id)
    {
      string path = hostingEnvironment.ContentRootPath + "\\" + "Projects" + "\\" + name;
      string folder = null;
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      folder = folderVersion.GetFolderVersion(path);
      var uploads = Path.Combine(path,
        path + folder); //Change to WebRootPath
      Directory.CreateDirectory(uploads);
      var pathFile = Path.Combine(uploads, file.FileName);
      using (var fileStream = new FileStream(pathFile, FileMode.Create))
      {
        file.CopyTo(fileStream);
      }
      folder = folder.Replace("\\", "/");

      ProjectFile projectFile = new ProjectFile
      {
        FileName = file.FileName,
        ProjectId = id,
        DefaultFolder = name,
        VersionFolder = folder,
        RevisionTime = DateTime.Now
      };
      ProjectRepository.InsertFile(projectFile);
    }

    public ProjectDTO GetProjectById(string id)
    {
      return AutoMapper.Mapper.Map<ProjectDTO>(ProjectRepository.GetProjectById(id));
    }

    public ProjectFileDTO GetFileById(string id)
    {
      List<string> files = new List<string>();

      var item = ProjectRepository.GetFilesById(id);
      try
      {
        using (ZipArchive archive = ZipFile.OpenRead(hostingEnvironment.ContentRootPath
                                                     + "\\" + "Projects"
                                                     + "\\" + item.DefaultFolder
                                                     + "\\" + item.VersionFolder
                                                     + "\\" + item.FileName))
        {
          foreach (var collection in archive.Entries)
          {
            files.Add(collection.FullName);
          }
        }
        ProjectFileDTO fileDto = new ProjectFileDTO
        {
          listFile = files,
          Version = item.VersionFolder
        };
        return fileDto;
      }
      catch (Exception e)
      {
        ProjectFileDTO fileDto = new ProjectFileDTO
        {
          listFile = new List<string>(),
          Version = ""
        };
        return fileDto;
      }
    }
    public ProjectFileDTO GetFileByDate(DateTime date, string id)
    {
      List<string> list = new List<string>();
      var folder = ProjectRepository.GetFilesByDate(date, id);
      try
      {
        string path = hostingEnvironment.ContentRootPath + "\\" + "Projects" + "\\" + folder.DefaultFolder;
        using (ZipArchive archive = ZipFile.OpenRead(path + "\\" + folder.VersionFolder + "\\" + folder.FileName))
        {
          foreach (var collection in archive.Entries)
          {
            list.Add(collection.FullName);
          }
        }
        ProjectFileDTO fileDto = new ProjectFileDTO
        {
          Version = folder.VersionFolder,
          listFile = list
        };
        return fileDto;
      }
      catch (Exception e)
      {
        ProjectFileDTO fileDto = new ProjectFileDTO
        {
          Version = "",
          listFile = new List<string>()
        };
        return fileDto;
      }
      
    }
    public List<DateTime> GetDatesById(string id)
    {
      return ProjectRepository.GetDatesById(id);
    }
    public void Insert(ProjectDTO projectDto)
    {
      projectDto.RevisionTime = DateTime.Now;
      projectDto.Id = 0;
      ProjectRepository.Insert(AutoMapper.Mapper.Map<ProjectDTO, Projects>(projectDto));
    }

    public void Delete(string id)
    {
      ProjectRepository.Delete(id);
    }
    public ProjectDTO GetDataByDate(DateTime date, string id)
    {
      return AutoMapper.Mapper.Map<ProjectDTO>(ProjectRepository.GetDataByDate(date, id));
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;
using BLL.Infrastructure;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.RegistrationMailData;
using Domain.Request;

namespace BLL
{
  public class FileService : IFileService
  {
    private IFileRepository fileRepository { get; }

    public FileService(IFileRepository repos)
    {
      fileRepository = repos;
    }

    public void AddFile(FileDTO fileDto)
    {
      BinaryFileData binDataToRepository = new BinaryFileData
      {
        Content = fileDto.BinaryData.Content
      };
      File fileToRepository = new File
      {
        FileName = fileDto.FileName,
        BinaryData = binDataToRepository,
        ContentType = fileDto.ContentType,
        CreatedDate = DateTime.Now,
        FileIndex = fileDto.FileIndex,
        RequestFormToken = fileDto.RequestFormToken
      };
      fileRepository.Insert(fileToRepository);
    }

    public IEnumerable<FileDTO> GetAllFiles()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<FileDTO> GetById(int id)
    {
      return fileRepository.GetById(id);
    }
  }
}

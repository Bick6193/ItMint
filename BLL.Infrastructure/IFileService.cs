using System;
using System.Collections.Generic;
using System.Text;
using Domain.Request;
namespace BLL.Infrastructure
{
  public interface IFileService
  {
    IEnumerable<FileDTO> GetAllFiles();

    IEnumerable<FileDTO> GetById(int id);

    void AddFile(FileDTO fileDto);

    BinaryDataDTO DownloadById(int idReq, int idFile);
  }
}

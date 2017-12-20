using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Domain.Request;

namespace DAL.Repositories.Infrastructure
{
  public interface IFileRepository
  {
    IEnumerable<FileDTO> GetById(int id);

    void Insert(File fileDto);

    BinaryDataDTO DownloadById(int idReq, int idFile);
  }
}

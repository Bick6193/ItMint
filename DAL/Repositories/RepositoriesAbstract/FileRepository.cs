using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Model;
using DAL.Repositories.Infrastructure;
using Domain.Request;
using Microsoft.EntityFrameworkCore.Internal;
using File = DAL.Models.File;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class FileRepository : IFileRepository
  {

    private ApplicationContext ApplicationContext { get; }

    public FileRepository(ApplicationContext context)
    {
      ApplicationContext = context;
    }

    public IEnumerable<FileDTO> GetById(int id)
    {
      string mainToken = (from i in ApplicationContext.Requests where i.Id == id select i.UserId).LastOrDefault().ToString();

      IEnumerable<File> files = from i in ApplicationContext.Files where i.RequestFormToken == mainToken select i;

      return AutoMapper.Mapper.Map<List<FileDTO>>(files);
    }

    public void Insert(File file)
    {
      var token = from i in ApplicationContext.Files
                  where i.RequestFormToken == file.RequestFormToken
                  select i;
      if (token.Count() > 5)
      {
        return;
      }
      ApplicationContext.Files.Add(file);
      ApplicationContext.SaveChanges();
    }

    public BinaryDataDTO DownloadById(int requestId, int fileId)
    {

      //var test = from i in ApplicationContext.Requests
      //           where i.Id == idReq
      //           select new
      //           {
      //             item = from o in i.Files
      //                    where o.Id == idFile
      //                    select new
      //                    {
      //                      o.FileName
      //                    }
      //           };

      var request = ApplicationContext.Requests.First(x => x.Id == requestId);
      var file = ApplicationContext.Files.Single(x => x.Id == fileId && x.RequestFormToken == request.UserId);
      var binary = ApplicationContext.BinaryFilesData.Single(x => x.Id == file.Id);

      //var item = ApplicationContext.Requests.Where(x => x.Id == idReq).Select(y => y.Files);

      //foreach (var collection in item)
      //{
      //  var i = collection;
      //}
      //var item = ApplicationContext.Files.Where(x => x.Id == id).Select(x=>x.BinaryData.Content).LastOrDefault();
      BinaryDataDTO fileDto = new BinaryDataDTO
      {
        Content = binary.Content
      };
      return fileDto;
    }
  }
}

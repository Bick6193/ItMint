﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.Request;

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
    public void Insert(File fileDto)
    {
      var tokenCount = from i in ApplicationContext.Files
                       where i.RequestFormToken == fileDto.RequestFormToken
                       select i;
      if (tokenCount.Count() > 5)
      {
        return;
      }
      ApplicationContext.Files.Add(fileDto);
      ApplicationContext.SaveChanges();
    }
  }
}

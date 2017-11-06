using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class RequestRepository : BaseRepository, IRequestRepository
  {
    private ApplicationContext applicationContext;

    public RequestRepository(ApplicationContext context) : base(context)
    {
      this.applicationContext = context;
    }

    public IEnumerable<Request> GetAll()
    {
      return applicationContext.Requests;
    }

    public Request GetById(int id)
    {
      return applicationContext.Requests.Find(id);
    }
      
    public void Insert(Request request)
    {
      applicationContext.Requests.Add(request);
    }

    public void Delete(int id)
    {
      Request request = applicationContext.Requests.Find(id);
      if (request != null)
      {
        applicationContext.Requests.Remove(request);
      }
    }


  }
}

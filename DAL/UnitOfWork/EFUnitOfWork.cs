using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Repositories.Infrastructure;
using DAL.Repositories.RepositoriesAbstract;

namespace DAL.UnitOfWork
{
  public class EFUnitOfWork : IUnitOfWork
  {
    private ApplicationContext applicationContext;
    private RequestRepository requestRepository;

    public EFUnitOfWork(string conString)
    {
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          applicationContext.Dispose();
        }
        this.disposed = true;
      }
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public IRequestRepository Requests
    {
      get
      {
        if (requestRepository == null)
        {
          requestRepository = new RequestRepository(applicationContext);
        }
        return requestRepository;
      }
    }
    public void Save()
    {
      applicationContext.SaveChanges();
    }
  }
}

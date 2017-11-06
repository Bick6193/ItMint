using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Infrastructure;

namespace DAL.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IRequestRepository Requests { get; }
    void Save();
  }
}

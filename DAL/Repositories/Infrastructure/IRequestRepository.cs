using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using JetBrains.Annotations;

namespace DAL.Repositories.Infrastructure
{
  public interface IRequestRepository
  {
    [NotNull]
    [MustUseReturnValue]
    IEnumerable<Request> GetAll();

    [NotNull]
    [MustUseReturnValue]
    Request GetById(int id);

    void Insert(Request request);

    void Delete(int id);
  }
}

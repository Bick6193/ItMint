using System.Collections;
using System.Collections.Generic;
using DAL.Models;
using DAL.Repositories.RepositoriesAbstract;
using Domain.Request;
using JetBrains.Annotations;

namespace DAL.Repositories.Infrastructure
{
  public interface IRequestRepository
  {
    IEnumerable<RequestDTO> GetAll();

    [NotNull]
    [MustUseReturnValue]
    RequestDTO GetById(int id);

    IEnumerable<RequestDTO> BasicSearch(InboxPanelService dataContainer);

    DataRequestServices CountRequests();

    void Insert(Request request);

    void GetFlag(int id);

    void Delete(int id);
  }
}

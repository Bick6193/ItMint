using System.Linq;
using Domain;

namespace DAL.Repository
{
    public interface IBaseRepository<TEntity, TDomain> where TEntity : EntityBase, new() where TDomain : DomainBase, new()
    {
        TDomain GetById(long id);
        TDomain Upsert(TDomain upsertEntity);
        void Delete(long id);

       // ListResult<AttorneyDisplay> List(ListCriteria criteria);
    }
}

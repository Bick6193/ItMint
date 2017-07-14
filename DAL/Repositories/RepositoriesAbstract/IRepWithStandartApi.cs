using Domain;

namespace DAL.Repositories.RepositoriesAbstract
{
    public interface IRepWithStandartApi<TEntity, TDomain> where TEntity : EntityBase, new() where TDomain : DomainBase, new()
    {
        TDomain GetById(long id);
        TDomain Upsert(TDomain upsertEntity);
        void Delete(long id);

       // ListResult<AttorneyDisplay> List(ListCriteria criteria);
    }
}

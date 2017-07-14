using System.Collections.Generic;
using System.Linq;
using Domain;
using AutoMapper;
using DAL.Context;
using DAL.Repositories.RepositoriesAbstract;
using DAL.SafeDelete;
using Domain.SafeDelete;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class RepWithStandartApi<TEntity, TDomain> : BaseRepository, IRepWithStandartApi<TEntity, TDomain> 
                                                        where TEntity : EntityBase, new() 
                                                        where TDomain : DomainBase, new()
    {
        protected readonly List<IExternalReferenceDescriptor> ExternalReferences = new List<IExternalReferenceDescriptor>();

        private DbSet<TEntity> DbSet { get; }

        public RepWithStandartApi(ApplicationContext context) : base(context)
        {
            DbSet = Context.Set<TEntity>();
        }

        protected virtual TEntity GetEntity(long id)
        {
            return DbSet.First(x => x.Id == id);
        }

        public TDomain GetById(long id)
        {
            return Mapper.Map<TDomain>(GetEntity(id));
        }

        public virtual TDomain Upsert(TDomain upsertEntity)
        {
            var entity = !upsertEntity.IsNew ? GetEntity(upsertEntity.Id) : new TEntity();

            Mapper.Map(upsertEntity, entity);

            if (upsertEntity.IsNew)
            {
                DbSet.Add(entity);
            }

            Context.SaveChanges();

            return GetById(entity.Id);
        }

        public void Delete(long id)
        {
            DeleteInternal(id);
        }
        
        protected virtual void DeleteInternal(long id)
        {
            var entity = GetEntity(id);

            Context.Entry(entity).State = EntityState.Deleted;

            Context.SaveChanges();
        }

        protected SafeDeleteResult CheckExternalReferences(long id)
        {
            SafeDeleteResult checkResult = new SafeDeleteResult();

            foreach (var navigationProperty in ExternalReferences)
            {
                var numberOfItems = navigationProperty.Count(id);

                if (numberOfItems > 0)
                {
                    checkResult.References.Add(new EntityExternalReference()
                    {
                        Count = numberOfItems,
                        Type = navigationProperty.Type
                    });
                }
            }

            return checkResult;
        }
    }
}

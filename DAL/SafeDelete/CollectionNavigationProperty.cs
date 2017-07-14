using System;
using System.Linq;
using System.Linq.Expressions;
using Domain;
using Domain.Audit;
using Microsoft.EntityFrameworkCore;

namespace DAL.SafeDelete
{
    public interface IExternalReferenceDescriptor
    {
        AuditObject Type { get; }

        int Count(long foreignKey);
    }

    public class ExternalReferenceDescriptor<TEntity> : IExternalReferenceDescriptor where TEntity : EntityBase
    {
        public AuditObject Type { get; }

        private Expression<Func<TEntity, long?>> ForeignKeyExpression { get; }

        private Expression<Func<TEntity, bool>> PreventDeleteCondition { get; }

        private DbContext Context { get; }
        
        public ExternalReferenceDescriptor(DbContext context, Expression<Func<TEntity, long?>> foreignKeyExpression, Expression<Func<TEntity, bool>> preventDeleteCondition = null)
        {
            ForeignKeyExpression = foreignKeyExpression;
            PreventDeleteCondition = preventDeleteCondition;
            Context = context;
            //Type = AuditConverter.GetAuditObject(typeof(TEntity).FullName);
        }

        public int Count(long foreignKey)
        {
            var query =  Context.Set<TEntity>().AsQueryable();

            if (PreventDeleteCondition != null)
            {
                query = query.Where(PreventDeleteCondition);
            }
            
            return query.Select(ForeignKeyExpression).Count(x => x == foreignKey);
        }
    }
}

using System;
using System.Data;
using DAL.Context;
using DAL.Repositories.Infrastructure;
using JetBrains.Annotations;

namespace DAL.Repositories
{
    [UsedImplicitly]
    public class TransactionManager : ITransactionManager
    {
        private ApplicationContext Context { get; }

        public TransactionManager(ApplicationContext context)
        {
            Context = context;
        }

        public void DoInTransaction(Action action, IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            Context.DoInTransaction(action);
        }
        
        public T DoInTransaction<T>(Func<T> func, IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            return Context.DoInTransaction(func);
        }
    }
}
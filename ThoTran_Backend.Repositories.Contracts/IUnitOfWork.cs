using System;
using System.Collections.Generic;
using System.Data.Common;

namespace $safeprojectname$.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IList<TEntity> ExecuteStoredProcedure<TEntity>(string commandText, bool isSetTimeOut = false,
            params DbParameter[] parameters);


        void ExecuteStoreProcedureNonQuery(string commandText, bool isSetTimeOut = false,
            params DbParameter[] parameters);

        IList<TEntity> ExecuteSqlQuery<TEntity>(string commandText, params object[] parameters);
    }
}

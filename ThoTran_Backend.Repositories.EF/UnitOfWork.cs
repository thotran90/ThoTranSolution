using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using $safeprojectname$.Contracts;
using $safeprojectname$.Contracts;

namespace $safeprojectname$
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _db;
        public UnitOfWork(IDbFactory db)
        {
            this._db = db;
        }
        public void Commit()
        {
            _db.GetInstance().SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.GetInstance().Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IList<TEntity> ExecuteSqlQuery<TEntity>(string commandText, params object[] parameters)
            => _db.GetInstance().Database.SqlQuery<TEntity>(commandText, parameters).ToList();

        public IList<TEntity> ExecuteStoredProcedure<TEntity>(string commandText, bool isSetTimeOut = false,
            params DbParameter[] parameters)
        {
            commandText = commandText + " " + string.Join(", ", parameters.Select(p =>
            {
                if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                {
                    return "@" + p.ParameterName + " output";
                }
                return "@" + p.ParameterName;
            }));
            var oldTimeOut = _db.GetInstance().Database.CommandTimeout;
            List<TEntity> result = null;
            if (isSetTimeOut)
            {
                _db.GetInstance().Database.CommandTimeout = 1800; // 30 minutes
            }
            try
            {
                result = _db.GetInstance().Database.SqlQuery<TEntity>(commandText, parameters).ToList();
            }
            finally
            {
                _db.GetInstance().Database.CommandTimeout = oldTimeOut;
            }
            return result;
        }

        public void ExecuteStoreProcedureNonQuery(string commandText, bool isSetTimeOut = false,
            params DbParameter[] parameters)
        {
            var oldTimeOut = _db.GetInstance().Database.CommandTimeout;
            if (isSetTimeOut)
            {
                _db.GetInstance().Database.CommandTimeout = 1800; // 30 minutes
            }
            try
            {
                _db.GetInstance().Database.ExecuteSqlCommand(commandText, parameters);
            }
            finally
            {
                _db.GetInstance().Database.CommandTimeout = oldTimeOut;
            }
        }

        private void SetTimeOut(bool isSetTimeOut)
        {
            if (isSetTimeOut)
            {
                _db.GetInstance().Database.CommandTimeout = 1800;
            }
        }
    }
}

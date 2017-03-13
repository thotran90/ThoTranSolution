using System.Data.Entity;
using $safeprojectname$.EntityFramework;
using $safeprojectname$.Repositories.EF.Contracts;

namespace $safeprojectname$.Repositories.EF
{
    public class DbFactory : IDbFactory
    {
        private static DbContext _dbContext;
        public DbFactory()
        {
            if (_dbContext == null)
                _dbContext = new AppDbContext();
        }

        public DbContext GetInstance()
            => _dbContext ?? (_dbContext = new AppDbContext());

    }
}

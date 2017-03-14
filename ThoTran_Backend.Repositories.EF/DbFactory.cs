using System.Data.Entity;
using $safeprojectname$.Contracts;

namespace $safeprojectname$
{
    public class DbFactory : IDbFactory
{
    private static DbContext _dbContext;
    public DbFactory()
    {
        if (_dbContext == null)
            _dbContext = new $safeprojectname$.AppDbContext();
    }

    public DbContext GetInstance()
        => _dbContext ?? (_dbContext = new $safeprojectname$.AppDbContext());

    }
}

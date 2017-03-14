using System.Data.Entity;

namespace $safeprojectname$.Contracts
{
    public interface IDbFactory
{
    DbContext GetInstance();
}
}

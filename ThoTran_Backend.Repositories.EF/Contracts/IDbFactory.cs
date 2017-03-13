using System.Data.Entity;

namespace $safeprojectname$.Repositories.EF.Contracts
{
    public interface IDbFactory
    {
        DbContext GetInstance();
    }
}

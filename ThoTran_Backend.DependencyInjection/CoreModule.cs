using Autofac;
using $safeprojectname$.Repositories.Contracts;
using $safeprojectname$.Repositories.EF;
using $safeprojectname$.Repositories.EF.Contracts;

namespace $safeprojectname$.DependencyInjection
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();
            base.Load(builder);
        }
    }
}

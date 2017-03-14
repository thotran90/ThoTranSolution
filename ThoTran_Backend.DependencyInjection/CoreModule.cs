using Autofac;

namespace $safeprojectname$
{
    public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType <$safeprojectname$.DbFactory>().As <$safeprojectname$.Contracts.IDbFactory>().InstancePerRequest();
        builder.RegisterType <$safeprojectname$.UnitOfWork>().As <$safeprojectname$.IUnitOfWork>().InstancePerRequest();
        builder.RegisterGeneric(typeof($safeprojectname$.EfRepository<>))
            .As(typeof($safeprojectname$.IRepository<>))
            .InstancePerDependency();
        base.Load(builder);
    }
}
}

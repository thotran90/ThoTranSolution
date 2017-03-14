using Autofac;

namespace $safeprojectname$
{
    public class ServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Add your service here
        builder.RegisterType <$safeprojectname$.ApplicationService > ()
             .As <$safeprojectname$.IApplicationService > ()
              .InstancePerRequest();
        builder.RegisterType <$safeprojectname$.UserService > ()
            .As <$safeprojectname$.IUserService > ()
             .InstancePerRequest();
        base.Load(builder);
    }
}
}

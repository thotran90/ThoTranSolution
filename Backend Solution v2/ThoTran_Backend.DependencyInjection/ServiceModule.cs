using Autofac;
using $safeprojectname$.Services;
using $safeprojectname$.Services.Contracts;

namespace $safeprojectname$.DependencyInjection
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Add your service here
            builder.RegisterType<ApplicationService>()
                .As<IApplicationService>()
                .InstancePerRequest();
            builder.RegisterType<UserService>()
               .As<IUserService>()
               .InstancePerRequest();
            base.Load(builder);
        }
    }
}

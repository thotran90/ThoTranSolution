namespace $safeprojectname$.Migrations
{
    using System.Data.Entity.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<$safeprojectname$.AppDbContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed($safeprojectname$.AppDbContext context)
    {
        //  This method will be called after migrating to the latest version.
        context.AppInformations.AddOrUpdate(app => app.Description,
            new Domain.Core.ApplicationInformation { Description = "Tho.Tran Backend Solution" });
    }
}
}

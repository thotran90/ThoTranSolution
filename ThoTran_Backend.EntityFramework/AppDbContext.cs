using System.Data.Entity;
using $safeprojectname$.Domain.Core;
using $safeprojectname$.EntityFramework.Mapping;

namespace $safeprojectname$.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyEntities")
        {

        }

        public DbSet<ApplicationInformation> AppInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationInformationMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

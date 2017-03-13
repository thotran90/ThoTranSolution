using System.Data.Entity.ModelConfiguration;
using $safeprojectname$.Domain.Core;

namespace $safeprojectname$.EntityFramework.Mapping
{
    public class ApplicationInformationMapping : EntityTypeConfiguration<ApplicationInformation>
    {
        public ApplicationInformationMapping()
        {
            ToTable("ApplicationInformation", "dbo");
            HasKey(app => app.AppId);
            Property(app => app.AppId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(app => app.Description).IsRequired().HasMaxLength(1000).HasColumnType("nvarchar");
        }
    }
}

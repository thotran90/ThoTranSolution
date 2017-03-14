namespace $safeprojectname$.Migrations
{
using System.Data.Entity.Migrations;

public partial class InitDB : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.ApplicationInformation",
            c => new
            {
                AppId = c.Int(nullable: false, identity: true),
                Description = c.String(nullable: false, maxLength: 1000),
            })
            .PrimaryKey(t => t.AppId);

    }

    public override void Down()
    {
        DropTable("dbo.ApplicationInformation");
    }
}
}

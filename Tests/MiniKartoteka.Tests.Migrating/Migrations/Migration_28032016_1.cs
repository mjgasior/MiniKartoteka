using FluentMigrator;

namespace MiniKartoteka.Tests.Migrating.Migrations
{
    [Migration(280320161)]
    public class Migration_28032016_1 : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("UserId").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("PhoneNumber").AsString();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}

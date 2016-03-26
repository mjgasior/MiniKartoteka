using FluentMigrator;

namespace MiniKartoteka.Tests.Migrating.Migrations
{
    [Migration(1)]
    public class _001_UsersTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Users");
        }

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsString(256)
                .WithColumn("password_hash").AsString(128);
        }
    }
}

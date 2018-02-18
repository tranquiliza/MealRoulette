namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class EventIds : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EventData");
            RenameColumn("dbo.EventData", "Id", "EventIdentifier");
            AddColumn("dbo.EventData", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.EventData", "Id");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.EventData");
            DropColumn("dbo.EventData", "Id");
            RenameColumn("dbo.EventData", "EventIdentifier", "Id");
            AlterColumn("dbo.EventData", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.EventData", "Id");
        }
    }
}

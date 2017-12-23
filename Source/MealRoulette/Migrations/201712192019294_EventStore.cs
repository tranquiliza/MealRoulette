namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EventType = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventData");
        }
    }
}

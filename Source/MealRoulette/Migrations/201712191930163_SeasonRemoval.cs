namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeasonRemoval : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meal", "Season_Id", "dbo.Season");
            DropIndex("dbo.Meal", new[] { "Season_Id" });
            DropColumn("dbo.Meal", "Season_Id");
            DropTable("dbo.Season");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Season",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Meal", "Season_Id", c => c.Int());
            CreateIndex("dbo.Meal", "Season_Id");
            AddForeignKey("dbo.Meal", "Season_Id", "dbo.Season", "Id");
        }
    }
}

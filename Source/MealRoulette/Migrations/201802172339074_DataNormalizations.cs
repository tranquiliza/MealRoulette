namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNormalizations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HardwareCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Meal", "CountryOfOrigin_Id", c => c.Int());
            AddColumn("dbo.Meal", "HardwareCategory_Id", c => c.Int());
            CreateIndex("dbo.Meal", "CountryOfOrigin_Id");
            CreateIndex("dbo.Meal", "HardwareCategory_Id");
            AddForeignKey("dbo.Meal", "CountryOfOrigin_Id", "dbo.Country", "Id");
            AddForeignKey("dbo.Meal", "HardwareCategory_Id", "dbo.HardwareCategory", "Id");
            DropColumn("dbo.Meal", "CountryOfOrigin");
            DropColumn("dbo.Meal", "HardwareCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meal", "HardwareCategory", c => c.String(maxLength: 200));
            AddColumn("dbo.Meal", "CountryOfOrigin", c => c.String(maxLength: 200));
            DropForeignKey("dbo.Meal", "HardwareCategory_Id", "dbo.HardwareCategory");
            DropForeignKey("dbo.Meal", "CountryOfOrigin_Id", "dbo.Country");
            DropIndex("dbo.Meal", new[] { "HardwareCategory_Id" });
            DropIndex("dbo.Meal", new[] { "CountryOfOrigin_Id" });
            DropColumn("dbo.Meal", "HardwareCategory_Id");
            DropColumn("dbo.Meal", "CountryOfOrigin_Id");
            DropTable("dbo.HardwareCategory");
            DropTable("dbo.Country");
        }
    }
}

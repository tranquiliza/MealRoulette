namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitOfMeasurementRework : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitOfMeasurement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MealIngredient", "UnitOfMeasurement_Id", c => c.Int());
            CreateIndex("dbo.MealIngredient", "UnitOfMeasurement_Id");
            AddForeignKey("dbo.MealIngredient", "UnitOfMeasurement_Id", "dbo.UnitOfMeasurement", "Id");
            DropColumn("dbo.MealIngredient", "UnitOfMeasurement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MealIngredient", "UnitOfMeasurement", c => c.String());
            DropForeignKey("dbo.MealIngredient", "UnitOfMeasurement_Id", "dbo.UnitOfMeasurement");
            DropIndex("dbo.MealIngredient", new[] { "UnitOfMeasurement_Id" });
            DropColumn("dbo.MealIngredient", "UnitOfMeasurement_Id");
            DropTable("dbo.UnitOfMeasurement");
        }
    }
}

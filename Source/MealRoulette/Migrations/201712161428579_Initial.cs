namespace MealRoulette.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        IsFastFood = c.Boolean(nullable: false),
                        IsVegetarianFriendly = c.Boolean(nullable: false),
                        HardwareCategory = c.String(),
                        Recipe = c.String(),
                        Holiday_Id = c.Int(),
                        MealCategory_Id = c.Int(),
                        Season_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Holiday", t => t.Holiday_Id)
                .ForeignKey("dbo.MealCategory", t => t.MealCategory_Id)
                .ForeignKey("dbo.Season", t => t.Season_Id)
                .Index(t => t.Holiday_Id)
                .Index(t => t.MealCategory_Id)
                .Index(t => t.Season_Id);
            
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        UnitOfMeasurement = c.String(),
                        Ingredient_Id = c.Int(),
                        Meal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id)
                .ForeignKey("dbo.Meal", t => t.Meal_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Meal_Id);
            
            CreateTable(
                "dbo.Season",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meal", "Season_Id", "dbo.Season");
            DropForeignKey("dbo.Meal", "MealCategory_Id", "dbo.MealCategory");
            DropForeignKey("dbo.MealIngredient", "Meal_Id", "dbo.Meal");
            DropForeignKey("dbo.MealIngredient", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.Meal", "Holiday_Id", "dbo.Holiday");
            DropIndex("dbo.MealIngredient", new[] { "Meal_Id" });
            DropIndex("dbo.MealIngredient", new[] { "Ingredient_Id" });
            DropIndex("dbo.Meal", new[] { "Season_Id" });
            DropIndex("dbo.Meal", new[] { "MealCategory_Id" });
            DropIndex("dbo.Meal", new[] { "Holiday_Id" });
            DropTable("dbo.Season");
            DropTable("dbo.MealIngredient");
            DropTable("dbo.Meal");
            DropTable("dbo.MealCategory");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Holiday");
        }
    }
}

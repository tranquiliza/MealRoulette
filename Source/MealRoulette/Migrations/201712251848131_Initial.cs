namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EventType = c.String(maxLength: 300),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CountryOfOrigin = c.String(maxLength: 200),
                        IsFastFood = c.Boolean(nullable: false),
                        IsVegetarianFriendly = c.Boolean(nullable: false),
                        HardwareCategory = c.String(maxLength: 200),
                        Recipe = c.String(maxLength: 3000),
                        Holiday_Id = c.Int(),
                        MealCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Holiday", t => t.Holiday_Id)
                .ForeignKey("dbo.MealCategory", t => t.MealCategory_Id)
                .Index(t => t.Holiday_Id)
                .Index(t => t.MealCategory_Id);
            
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Ingredient_Id = c.Int(),
                        UnitOfMeasurement_Id = c.Int(),
                        Meal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id)
                .ForeignKey("dbo.UnitOfMeasurement", t => t.UnitOfMeasurement_Id)
                .ForeignKey("dbo.Meal", t => t.Meal_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.UnitOfMeasurement_Id)
                .Index(t => t.Meal_Id);
            
            CreateTable(
                "dbo.UnitOfMeasurement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealIngredient", "Meal_Id", "dbo.Meal");
            DropForeignKey("dbo.MealIngredient", "UnitOfMeasurement_Id", "dbo.UnitOfMeasurement");
            DropForeignKey("dbo.MealIngredient", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.Meal", "MealCategory_Id", "dbo.MealCategory");
            DropForeignKey("dbo.Meal", "Holiday_Id", "dbo.Holiday");
            DropIndex("dbo.MealIngredient", new[] { "Meal_Id" });
            DropIndex("dbo.MealIngredient", new[] { "UnitOfMeasurement_Id" });
            DropIndex("dbo.MealIngredient", new[] { "Ingredient_Id" });
            DropIndex("dbo.Meal", new[] { "MealCategory_Id" });
            DropIndex("dbo.Meal", new[] { "Holiday_Id" });
            DropTable("dbo.UnitOfMeasurement");
            DropTable("dbo.MealIngredient");
            DropTable("dbo.Meal");
            DropTable("dbo.MealCategory");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Holiday");
            DropTable("dbo.EventData");
        }
    }
}

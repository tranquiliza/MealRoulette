namespace MealRoulette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MealDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meal", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meal", "Description");
        }
    }
}

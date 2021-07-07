namespace WpfServiceTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestaurantName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Shops", newName: "Restaurants");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Restaurants", newName: "Shops");
        }
    }
}

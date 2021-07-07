namespace WpfServiceTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 256),
                        Street = c.String(nullable: false, maxLength: 256),
                        BuildingNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        PhoneNumber = c.String(nullable: false, maxLength: 13),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientData_Id = c.Int(),
                        GoodsData_Id = c.Int(),
                        RestaurantData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientData_Id)
                .ForeignKey("dbo.Goods", t => t.GoodsData_Id)
                .ForeignKey("dbo.Shops", t => t.RestaurantData_Id)
                .Index(t => t.ClientData_Id)
                .Index(t => t.GoodsData_Id)
                .Index(t => t.RestaurantData_Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "RestaurantData_Id", "dbo.Shops");
            DropForeignKey("dbo.Shops", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "GoodsData_Id", "dbo.Goods");
            DropForeignKey("dbo.Orders", "ClientData_Id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Shops", new[] { "Address_Id" });
            DropIndex("dbo.Orders", new[] { "RestaurantData_Id" });
            DropIndex("dbo.Orders", new[] { "GoodsData_Id" });
            DropIndex("dbo.Orders", new[] { "ClientData_Id" });
            DropIndex("dbo.Clients", new[] { "Address_Id" });
            DropTable("dbo.Shops");
            DropTable("dbo.Orders");
            DropTable("dbo.Goods");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}

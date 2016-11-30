namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Int(nullable: false),
                        Admin_Id = c.Int(),
                        Client_Id = c.Int(),
                        ItemName_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Catalogues", t => t.ItemName_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Admin_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.ItemName_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusValue = c.Int(nullable: false),
                        Admin_Id = c.Int(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.Admin_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Status", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Status", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Orders", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.Status", new[] { "Supplier_Id" });
            DropIndex("dbo.Status", new[] { "Admin_Id" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "ItemName_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Orders", new[] { "Admin_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
        }
    }
}

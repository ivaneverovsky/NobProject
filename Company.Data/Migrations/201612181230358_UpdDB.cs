namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues");
            DropForeignKey("dbo.Status", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Status", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropIndex("dbo.Orders", new[] { "Admin_Id" });
            DropIndex("dbo.Orders", new[] { "ItemName_Id" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.Status", new[] { "Admin_Id" });
            DropIndex("dbo.Status", new[] { "Supplier_Id" });
            AddColumn("dbo.Orders", "Client", c => c.String());
            AddColumn("dbo.Orders", "Admin", c => c.String());
            AddColumn("dbo.Orders", "ItemName", c => c.String());
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Admin_Id");
            DropColumn("dbo.Orders", "ItemName_Id");
            DropColumn("dbo.Orders", "Status_Id");
            DropTable("dbo.Status");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusValue = c.Int(nullable: false),
                        Admin_Id = c.Int(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Status_Id", c => c.Int());
            AddColumn("dbo.Orders", "ItemName_Id", c => c.Int());
            AddColumn("dbo.Orders", "Admin_Id", c => c.Int());
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "ItemName");
            DropColumn("dbo.Orders", "Admin");
            DropColumn("dbo.Orders", "Client");
            CreateIndex("dbo.Status", "Supplier_Id");
            CreateIndex("dbo.Status", "Admin_Id");
            CreateIndex("dbo.Orders", "Status_Id");
            CreateIndex("dbo.Orders", "ItemName_Id");
            CreateIndex("dbo.Orders", "Admin_Id");
            AddForeignKey("dbo.Orders", "Status_Id", "dbo.Status", "Id");
            AddForeignKey("dbo.Status", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.Status", "Admin_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues", "Id");
            AddForeignKey("dbo.Orders", "Admin_Id", "dbo.Admins", "Id");
        }
    }
}

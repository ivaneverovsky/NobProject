namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Price_Id", "dbo.Catalogues");
            DropForeignKey("dbo.Suppliers", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "Price_Id" });
            DropIndex("dbo.Suppliers", new[] { "Orders_Id" });
            AddColumn("dbo.Orders", "Cost", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Price_Id");
            DropColumn("dbo.Suppliers", "Orders_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Orders_Id", c => c.Int());
            AddColumn("dbo.Orders", "Price_Id", c => c.Int());
            DropColumn("dbo.Orders", "Cost");
            CreateIndex("dbo.Suppliers", "Orders_Id");
            CreateIndex("dbo.Orders", "Price_Id");
            AddForeignKey("dbo.Suppliers", "Orders_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Price_Id", "dbo.Catalogues", "Id");
        }
    }
}

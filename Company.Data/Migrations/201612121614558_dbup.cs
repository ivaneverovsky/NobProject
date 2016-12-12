namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues");
            DropIndex("dbo.Orders", new[] { "ItemName_Id" });
            AddColumn("dbo.Orders", "ItemName", c => c.String());
            DropColumn("dbo.Orders", "ItemName_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ItemName_Id", c => c.Int());
            DropColumn("dbo.Orders", "ItemName");
            CreateIndex("dbo.Orders", "ItemName_Id");
            AddForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues", "Id");
        }
    }
}

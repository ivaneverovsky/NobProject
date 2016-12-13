namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders_upd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ItemName_Id", c => c.Int());
            CreateIndex("dbo.Orders", "ItemName_Id");
            AddForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues", "Id");
            DropColumn("dbo.Orders", "ItemName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ItemName", c => c.String());
            DropForeignKey("dbo.Orders", "ItemName_Id", "dbo.Catalogues");
            DropIndex("dbo.Orders", new[] { "ItemName_Id" });
            DropColumn("dbo.Orders", "ItemName_Id");
        }
    }
}

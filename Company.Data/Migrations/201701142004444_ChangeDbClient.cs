namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDbClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "phone", c => c.String());
            AddColumn("dbo.Clients", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "email");
            DropColumn("dbo.Clients", "phone");
        }
    }
}

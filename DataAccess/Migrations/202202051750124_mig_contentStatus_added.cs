namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contentStatus_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "Status");
        }
    }
}

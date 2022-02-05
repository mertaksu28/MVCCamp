namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingStatus_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "Status");
        }
    }
}

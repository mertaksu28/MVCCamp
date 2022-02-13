namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_editPaswordAndUserName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "UserName", c => c.String(maxLength: 500));
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "UserName", c => c.String(maxLength: 50));
        }
    }
}

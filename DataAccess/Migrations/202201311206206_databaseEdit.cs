﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "WriterId", c => c.Int());
            CreateIndex("dbo.Contents", "WriterId");
            AddForeignKey("dbo.Contents", "WriterId", "dbo.Writers", "WriterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropColumn("dbo.Contents", "WriterId");
        }
    }
}

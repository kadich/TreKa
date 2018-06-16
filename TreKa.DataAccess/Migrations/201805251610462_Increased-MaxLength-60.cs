namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasedMaxLength60 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "test", c => c.Int(nullable: false));
        }
    }
}

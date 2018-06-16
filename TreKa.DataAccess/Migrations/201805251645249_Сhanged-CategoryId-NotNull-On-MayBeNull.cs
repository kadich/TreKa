namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class СhangedCategoryIdNotNullOnMayBeNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Exercises", new[] { "CategoryId" });
            AlterColumn("dbo.Exercises", "CategoryId", c => c.Int());
            CreateIndex("dbo.Exercises", "CategoryId");
            AddForeignKey("dbo.Exercises", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Exercises", new[] { "CategoryId" });
            AlterColumn("dbo.Exercises", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercises", "CategoryId");
            AddForeignKey("dbo.Exercises", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}

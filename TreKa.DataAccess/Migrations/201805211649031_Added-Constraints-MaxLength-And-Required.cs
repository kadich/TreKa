namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConstraintsMaxLengthAndRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 2));
        }
    }
}

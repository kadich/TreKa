namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnRepetition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Repetition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "Repetition");
        }
    }
}

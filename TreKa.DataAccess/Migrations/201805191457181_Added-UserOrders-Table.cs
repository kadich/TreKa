namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserOrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserOrderEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        AmountOfDays = c.Int(nullable: false),
                        ExceptLegs = c.Boolean(nullable: false),
                        ExceptArms = c.Boolean(nullable: false),
                        ExceptPress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserOrderEntities");
        }
    }
}

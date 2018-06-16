namespace TreKa.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTableUserOrderEntitytoUserOrders : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserOrderEntities", newName: "UserOrders");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserOrders", newName: "UserOrderEntities");
        }
    }
}

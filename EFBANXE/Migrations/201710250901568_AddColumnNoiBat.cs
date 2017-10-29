namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNoiBat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xes", "NoiBat", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Xes", "NoiBat");
        }
    }
}

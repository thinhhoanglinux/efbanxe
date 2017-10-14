namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TinTucs", "Hinh", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TinTucs", "Hinh", c => c.String(nullable: false));
        }
    }
}

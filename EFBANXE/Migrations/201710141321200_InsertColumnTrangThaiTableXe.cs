namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertColumnTrangThaiTableXe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xes", "TrangThai", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Xes", "TrangThai");
        }
    }
}

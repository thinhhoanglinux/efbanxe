namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTrangThaiTableTinTuc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TinTucs", "TrangThai", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TinTucs", "TrangThai");
        }
    }
}

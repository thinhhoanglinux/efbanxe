namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableDangKyLaiThu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangKyLaiThus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false),
                        Sdt = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        LoiNhan = c.String(nullable: false),
                        NgayDangKy = c.String(),
                        TrangThai = c.Boolean(nullable: false),
                        XeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Xes", t => t.XeId, cascadeDelete: true)
                .Index(t => t.XeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DangKyLaiThus", "XeId", "dbo.Xes");
            DropIndex("dbo.DangKyLaiThus", new[] { "XeId" });
            DropTable("dbo.DangKyLaiThus");
        }
    }
}

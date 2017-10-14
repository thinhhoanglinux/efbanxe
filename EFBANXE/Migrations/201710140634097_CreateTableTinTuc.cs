namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableTinTuc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiTinTucs",
                c => new
                    {
                        LoaiTinTucId = c.Int(nullable: false, identity: true),
                        TenLoaiTinTuc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoaiTinTucId);
            
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        TinTucId = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 255),
                        NoiDung = c.String(nullable: false),
                        ThoiGianDang = c.DateTime(nullable: false),
                        Hinh = c.String(nullable: false),
                        LoaiTinTucId = c.Int(nullable: false),
                        NhanVienId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TinTucId)
                .ForeignKey("dbo.LoaiTinTucs", t => t.LoaiTinTucId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.NhanVienId)
                .Index(t => t.LoaiTinTucId)
                .Index(t => t.NhanVienId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TinTucs", "NhanVienId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TinTucs", "LoaiTinTucId", "dbo.LoaiTinTucs");
            DropIndex("dbo.TinTucs", new[] { "NhanVienId" });
            DropIndex("dbo.TinTucs", new[] { "LoaiTinTucId" });
            DropTable("dbo.TinTucs");
            DropTable("dbo.LoaiTinTucs");
        }
    }
}

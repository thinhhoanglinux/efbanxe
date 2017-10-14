namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableXe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiXes",
                c => new
                    {
                        LoaiXeId = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.LoaiXeId);
            
            CreateTable(
                "dbo.Xes",
                c => new
                    {
                        XeId = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 255),
                        MoTa = c.String(nullable: false),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hinh = c.String(nullable: false),
                        DanhGia = c.String(nullable: false),
                        ThoiGian = c.DateTime(nullable: false),
                        LoaiXeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.XeId)
                .ForeignKey("dbo.LoaiXes", t => t.LoaiXeId, cascadeDelete: true)
                .Index(t => t.LoaiXeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Xes", "LoaiXeId", "dbo.LoaiXes");
            DropIndex("dbo.Xes", new[] { "LoaiXeId" });
            DropTable("dbo.Xes");
            DropTable("dbo.LoaiXes");
        }
    }
}

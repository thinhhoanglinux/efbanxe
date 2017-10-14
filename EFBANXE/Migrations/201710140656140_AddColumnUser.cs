namespace EFBANXE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HoTen", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "NgaySinh", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Sdt", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "DiaChi", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "NgayVaoLam", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "TrangThai", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TrangThai");
            DropColumn("dbo.AspNetUsers", "NgayVaoLam");
            DropColumn("dbo.AspNetUsers", "DiaChi");
            DropColumn("dbo.AspNetUsers", "Sdt");
            DropColumn("dbo.AspNetUsers", "NgaySinh");
            DropColumn("dbo.AspNetUsers", "HoTen");
        }
    }
}

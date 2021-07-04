namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "ApproveUser_Id" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropColumn("dbo.Events", "ApproveUserId");
            DropColumn("dbo.Events", "UserId");
            RenameColumn(table: "dbo.Events", name: "ApproveUser_Id", newName: "ApproveUserId");
            RenameColumn(table: "dbo.Events", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Events", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "ApproveUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "UserId");
            CreateIndex("dbo.Events", "ApproveUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Events", new[] { "ApproveUserId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            AlterColumn("dbo.Events", "ApproveUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Events", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Events", name: "ApproveUserId", newName: "ApproveUser_Id");
            AddColumn("dbo.Events", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "ApproveUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "User_Id");
            CreateIndex("dbo.Events", "ApproveUser_Id");
        }
    }
}

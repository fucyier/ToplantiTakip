namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Status", c => c.String(maxLength: 5));
            DropColumn("dbo.Events", "Approved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Approved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Events", "Status");
            DropColumn("dbo.Rooms", "RoomCapacity");
        }
    }
}

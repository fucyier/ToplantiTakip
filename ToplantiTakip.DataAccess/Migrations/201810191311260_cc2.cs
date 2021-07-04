namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "ApproveDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "ApproveDate", c => c.DateTime(nullable: false));
        }
    }
}

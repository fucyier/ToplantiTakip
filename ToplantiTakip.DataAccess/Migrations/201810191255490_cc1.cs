namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "ApproveDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}

namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "ApproveDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "ApproveDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}

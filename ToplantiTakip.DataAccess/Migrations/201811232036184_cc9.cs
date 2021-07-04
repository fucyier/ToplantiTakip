namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Status", c => c.String(maxLength: 5));
        }
    }
}

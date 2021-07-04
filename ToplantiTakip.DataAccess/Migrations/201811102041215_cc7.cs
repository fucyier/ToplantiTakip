namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventDocuments", newName: "EventDocument");
            AddColumn("dbo.EventDocument", "DocumentName", c => c.String());
            AlterColumn("dbo.EventDocument", "DocumentType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventDocument", "DocumentType", c => c.String());
            DropColumn("dbo.EventDocument", "DocumentName");
            RenameTable(name: "dbo.EventDocument", newName: "EventDocuments");
        }
    }
}

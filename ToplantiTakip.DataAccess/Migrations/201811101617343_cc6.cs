namespace ToplantiTakip.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventDocuments",
                c => new
                    {
                        EventDocumentId = c.Int(nullable: false, identity: true),
                        Document = c.Binary(),
                        DocumentType = c.String(),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventDocumentId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            DropColumn("dbo.Events", "Document");
            DropColumn("dbo.Events", "DocumentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "DocumentType", c => c.String(maxLength: 50));
            AddColumn("dbo.Events", "Document", c => c.Binary());
            DropForeignKey("dbo.EventDocuments", "EventId", "dbo.Events");
            DropIndex("dbo.EventDocuments", new[] { "EventId" });
            DropTable("dbo.EventDocuments");
        }
    }
}

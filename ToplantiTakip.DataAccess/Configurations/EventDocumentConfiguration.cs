using System.Data.Entity.ModelConfiguration;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Configurations
{
    class EventDocumentConfiguration : EntityTypeConfiguration<EventDocument>
    {
        public EventDocumentConfiguration()
        {
            HasKey(p => p.EventDocumentId);
            Property(p => p.Document).HasColumnName("Document");
            Property(p => p.DocumentType).HasMaxLength(50);
            HasRequired(p => p.Event).WithMany(p => p.EventDocument);
            ToTable("EventDocument");
        }
    }
}

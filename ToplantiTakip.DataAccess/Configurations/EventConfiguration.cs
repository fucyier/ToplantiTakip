using System.Data.Entity.ModelConfiguration;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Configurations
{
    class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            HasKey(p => p.EventId);
            Property(p => p.EventSubject).IsRequired().HasColumnName("Subject").HasMaxLength(500);
            Property(p => p.EventInfo).HasColumnName("Info").HasMaxLength(3000);
            Property(p => p.StatusString).HasColumnName("Status").HasMaxLength(50);

            HasRequired(p => p.Room).WithMany(p => p.Events);
            ToTable("Events");
        }
    }
}

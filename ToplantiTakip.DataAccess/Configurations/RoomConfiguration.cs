using System.Data.Entity.ModelConfiguration;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Configurations
{
    class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomConfiguration()
        {

            HasKey(p => p.RoomId);
            Property(p => p.RoomInfo).IsRequired().HasColumnName("Info").HasMaxLength(500);
            Property(p => p.RoomAddress).HasColumnName("Address").HasMaxLength(500);
            Property(p => p.RoomStatus).HasColumnName("Statu"); ;

            HasRequired(p => p.Department).WithMany(p => p.Rooms);
            ToTable("Rooms");
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Configurations
{
    class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            HasKey(p => p.DepartmentId);
            Property(p => p.DepartmentInfo).IsRequired().HasColumnName("Info").HasMaxLength(500);
            Property(p => p.DepartmentAddress).HasColumnName("Address").HasMaxLength(500);
            Property(p => p.DepartmentStatus).HasColumnName("Statu");

            ToTable("Departments");
        }
    }
}

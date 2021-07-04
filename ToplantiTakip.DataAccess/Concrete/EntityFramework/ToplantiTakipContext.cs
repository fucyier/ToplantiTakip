using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ToplantiTakip.DataAccess.Configurations;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Concrete.EntityFramework
{
    public class ToplantiTakipContext : IdentityDbContext<ApplicationUser>
    {
        public ToplantiTakipContext()
            : base("ToplantiTakipSiteContext", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ToplantiTakipContext>(new CreateDatabaseIfNotExists<ToplantiTakipContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ToplantiTakipContext Create()
        {
            return new ToplantiTakipContext();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDocument> EventDocuments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new EventDocumentConfiguration());
        }
    }

}

using crawler_api.Models;
using Microsoft.EntityFrameworkCore;

namespace crawler_api.Data
{
    public partial class DataContext : DbContext
    {
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>(e => e.HasKey(x => x.Code));
            modelBuilder.Entity<District>(e => e.HasKey(x => x.Code));
            modelBuilder.Entity<Ward>(e => e.HasKey(x => x.Code));
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
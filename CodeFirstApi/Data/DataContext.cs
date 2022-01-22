using CodeFirstApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DcFrameEntity> DcFrames { get; set; }
        public DbSet<DcManagerEntity> DcManagers { get; set; }
        public DbSet<DcClassEntity> DcClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<DcClassEntity>()
                .HasOne(d => d.DcFrame)
                .WithMany(e => e.DcClasses)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

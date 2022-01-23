using DbFirstApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApi.Data
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
        }
    }
}

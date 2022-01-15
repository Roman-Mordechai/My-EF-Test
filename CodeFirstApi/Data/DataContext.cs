using CodeFirstApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DcFrameEntity> DcFrames { get; set; }
        public DbSet<DcManagerEntity> DcManagers { get; set; }
        public DbSet<DcClassEntity> DcClases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcClassEntity>()
                .HasOne(d => d.DcFrame)
                .WithMany(e => e.Classes)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}

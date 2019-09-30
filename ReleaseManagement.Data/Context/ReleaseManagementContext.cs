using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReleaseManagement.Core.Models;

namespace ReleaseManagement.Data.Context {
    public class ReleaseManagementContext : DbContext {
        public ReleaseManagementContext() : base("DefaultConnection") {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<ReleasePlatform> ReleasePlatforms { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Properties<string>().Configure(s => s.HasColumnType("varchar").HasMaxLength(250));
            modelBuilder.Properties<string>().Configure(s => s.HasColumnType("varchar").HasMaxLength(250));

            modelBuilder.Entity<Feature>().Property(p => p.StatusCode).HasMaxLength(10);
            modelBuilder.Entity<Release>().Property(p => p.StatusCode).HasMaxLength(10);
            modelBuilder.Entity<WorkItem>().Property(p => p.StatusCode).HasMaxLength(10);
            modelBuilder.Entity<WorkItem>().Property(p => p.TypeCode).HasMaxLength(10);
            modelBuilder.Entity<Release>().HasMany(p=>p.Features).WithMany(p=>p.Releases)
                .Map(rf =>
                {
                    rf.MapLeftKey("ReleaseId");
                    rf.MapRightKey("FeaturesId");
                    rf.ToTable("ReleaseFeatures");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SamuraiScaffoldConsole
{
    public partial class SamuraiAppDataFirstLookContext : DbContext
    {
        public SamuraiAppDataFirstLookContext()
        {
        }

        public SamuraiAppDataFirstLookContext(DbContextOptions<SamuraiAppDataFirstLookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battle> Battles { get; set; } = null!;
        public virtual DbSet<Quote> Quotes { get; set; } = null!;
        public virtual DbSet<Samurai> Samurais { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiAppDataFirstLook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battle>(entity =>
            {
                entity.HasMany(d => d.Samurais)
                    .WithMany(p => p.BattlesBattles)
                    .UsingEntity<Dictionary<string, object>>(
                        "BattleSamurai",
                        l => l.HasOne<Samurai>().WithMany().HasForeignKey("SamuraisId"),
                        r => r.HasOne<Battle>().WithMany().HasForeignKey("BattlesBattleId"),
                        j =>
                        {
                            j.HasKey("BattlesBattleId", "SamuraisId");

                            j.ToTable("BattleSamurai");

                            j.HasIndex(new[] { "SamuraisId" }, "IX_BattleSamurai_SamuraisId");
                        });
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId, "IX_Quotes_SamuraiId");

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

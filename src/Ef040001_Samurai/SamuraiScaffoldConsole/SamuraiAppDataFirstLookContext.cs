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
        public virtual DbSet<BattleSamurai> BattleSamurais { get; set; } = null!;
        public virtual DbSet<Folder> Folders { get; set; } = null!;
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
            modelBuilder.Entity<BattleSamurai>(entity =>
            {
                entity.HasKey(e => new { e.BattleId, e.SamuraiId });

                entity.ToTable("BattleSamurai");

                entity.HasIndex(e => e.SamuraiId, "IX_BattleSamurai_SamuraiId");

                entity.Property(e => e.DateJoined).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.BattleSamurais)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.BattleSamurais)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasIndex(e => e.ParentId, "IX_Folders_ParentId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
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

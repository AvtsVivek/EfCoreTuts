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
            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId, "IX_Quotes_SamuraiId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text).HasColumnType("text");

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<Samurai>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestTask.Domain;
using TestTask.Application.Interfaces;

namespace TestTask.Persistance
//отвечает за взаимодействие с базой
{
    public partial class TestTaskDbContext : DbContext, ITestTaskDbContext 
    {
        public TestTaskDbContext()
        {
        }

        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventLog> EventLogs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductVersion> ProductVersions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.ToTable("EventLog");

                entity.HasIndex(e => e.EventDate, "EventLog_EventDate_Index");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.EventDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Name, "Product_Name_Index");

                entity.HasIndex(e => e.Name, "UQ__Product__737584F69DC8A3D8")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ProductVersion>(entity =>
            {
                entity.ToTable("ProductVersion");

                entity.HasIndex(e => new { e.Name, e.CreatingDate, e.Width, e.Height, e.Length }, "ProductVersion_Name_CreatingDate_Width_Height_Length_Index");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Length).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Width).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVersions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductVe__Produ__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

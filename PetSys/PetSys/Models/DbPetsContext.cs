using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetSys.Models;

public partial class DbPetsContext : DbContext
{
    public DbPetsContext()
    {
    }

    public DbPetsContext(DbContextOptions<DbPetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_booki__3213E83F93D4A2F4");

            entity.ToTable("tb_bookings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.IdTutor).HasColumnName("id_tutor");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_bookin__id_se__29572725");

            entity.HasOne(d => d.IdTutorNavigation).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.IdTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_bookin__id_tu__286302EC");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_servi__3213E83FC7467AF8");

            entity.ToTable("tb_service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Desc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("desc");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_tutor__3213E83F96205516");

            entity.ToTable("tb_tutor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PetName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("pet_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

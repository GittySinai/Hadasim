using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HMO_API.models;

public partial class HmoContext : DbContext
{
    public HmoContext()
    {
    }

    public HmoContext(DbContextOptions<HmoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<MedicalEvent> MedicalEvents { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<VaccinEvent> VaccinEvents { get; set; }

    public virtual DbSet<VaccineType> VaccineTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9SDKDAC\\SQLEXPRESS;Database=HMO; Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MedicalEvent>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventDate).HasColumnType("date");
            entity.Property(e => e.EventExtensionId).HasColumnName("EventExtensionID");
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.EventExtension).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.EventExtensionId)
                .HasConstraintName("FK_MedicalEvents_VaccinEvents");

            entity.HasOne(d => d.EventType).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalEvents_EventTypes");

            entity.HasOne(d => d.Member).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalEvents_Members");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tz)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TZ");
        });

        modelBuilder.Entity<VaccinEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Vaccine");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BodyLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.VaccineId).HasColumnName("VaccineID");

            entity.HasOne(d => d.Member).WithMany(p => p.VaccinEvents)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccins_Members");

            entity.HasOne(d => d.Vaccine).WithMany(p => p.VaccinEvents)
                .HasForeignKey(d => d.VaccineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccins_VaccineTypes");
        });

        modelBuilder.Entity<VaccineType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VaccineName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

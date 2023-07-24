using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AltunkayaBurada.Models;

public partial class AltunkayadbContext : DbContext
{
    public AltunkayadbContext()
    {
    }

    public AltunkayadbContext(DbContextOptions<AltunkayadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Altunsatable> Altunsatables { get; set; }

    public virtual DbSet<Confytable> Confytables { get; set; }

    public virtual DbSet<Mahmoodtable> Mahmoodtables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-H3SEJLE9; Initial Catalog=altunkayadb; Trusted_Connection=True; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Altunsatable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__altunsat__3213E83F401ECB75");

            entity.ToTable("altunsatable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.SontuketimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("sontuketimTarihi");
            entity.Property(e => e.UrunAdi)
                .HasMaxLength(100)
                .HasColumnName("urunAdi");
        });

        modelBuilder.Entity<Confytable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__confytab__3213E83F32A07D01");

            entity.ToTable("confytable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.SontuketimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("sontuketimTarihi");
            entity.Property(e => e.UrunAdi)
                .HasMaxLength(100)
                .HasColumnName("urunAdi");
        });

        modelBuilder.Entity<Mahmoodtable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mahmoodt__3213E83F6734997D");

            entity.ToTable("mahmoodtable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.SontuketimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("sontuketimTarihi");
            entity.Property(e => e.UrunAdi)
                .HasMaxLength(100)
                .HasColumnName("urunAdi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

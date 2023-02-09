using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AARCO_Examn.Models.DB;

public partial class DbAarcoExamContext : DbContext
{
    public DbAarcoExamContext()
    {
    }

    public DbAarcoExamContext(DbContextOptions<DbAarcoExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Descripcion> Descripcions { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Submarca> Submarcas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\Local; Database=DB_AARCO_Exam; Trusted_Connection=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Descripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Descripc__3214EC07B0DEB5E1");

            entity.ToTable("Descripcion");

            entity.Property(e => e.DescripcionId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Descripcions)
                .HasForeignKey(d => d.IdModelo)
                .HasConstraintName("FK_Descripcion_Modelo");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Marca__3214EC075795F58A");

            entity.ToTable("Marca");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Modelo__3214EC073F8747A9");

            entity.ToTable("Modelo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSubmarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdSubmarca)
                .HasConstraintName("FK_Modelo_Submarca");
        });

        modelBuilder.Entity<Submarca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Submarca__3214EC0759A55FCF");

            entity.ToTable("Submarca");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Submarcas)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK_Submarca_Marca");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

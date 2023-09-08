using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Confecciones_Condor_1.Models;

public partial class ConfeccionesCondorContext : DbContext
{
    public ConfeccionesCondorContext()
    {
    }

    public ConfeccionesCondorContext(DbContextOptions<ConfeccionesCondorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseMySql("server=localhost;port=3306;database=confecciones_condor;uid=root;password=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PRIMARY");

            entity.ToTable("areas");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.NombreArea).HasMaxLength(50);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.AreaId, "AreaID");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(20);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("empleados_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

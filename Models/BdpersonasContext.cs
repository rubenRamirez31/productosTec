using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EjercicioEFC.Models;

public partial class BdpersonasContext : DbContext
{
    public BdpersonasContext()
    {
    }

    public BdpersonasContext(DbContextOptions<BdpersonasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=database-2.cieq3dfbzdfd.us-east-2.rds.amazonaws.com; Port=3306; Database=BDPersonas; Uid=admin; Pwd=BT8OuIqJh6BF4Z8AsquH");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Categoria");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Ocupacion).HasMaxLength(100);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdCategoria, "fk_cat_pro");

            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Producto");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_cat_pro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

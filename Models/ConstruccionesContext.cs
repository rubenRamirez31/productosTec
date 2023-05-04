using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EjercicioEFC.Models;

public partial class ConstruccionesContext : DbContext
{
    public ConstruccionesContext()
    {
    }

    public ConstruccionesContext(DbContextOptions<ConstruccionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Construccione> Construcciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=database-2.cieq3dfbzdfd.us-east-2.rds.amazonaws.com; Port=3306; Database=Construcciones; Uid=admin; Pwd=BT8OuIqJh6BF4Z8AsquH");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Construccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Construccion).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaInicio).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public static implicit operator ConstruccionesContext(BdpersonasContext v)
    {
        throw new NotImplementedException();
    }
}

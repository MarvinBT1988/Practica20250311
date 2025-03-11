using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practica20250311.AppWebMVC.Models;

public partial class Practica20250311DbContext : DbContext
{
    public Practica20250311DbContext()
    {
    }

    public Practica20250311DbContext(DbContextOptions<Practica20250311DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC079ADB9534");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Marcas__3214EC07B065A516");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC079A560337");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Categ__3C69FB99");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Marca__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07AA20F010");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053427262548").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UltimoInicioSesion).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

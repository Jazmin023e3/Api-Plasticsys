using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlasticSYS.Models;

public partial class PlasticSysContext : DbContext
{
    public PlasticSysContext()
    {
    }

    public PlasticSysContext(DbContextOptions<PlasticSysContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A78B34D3CD");

            entity.HasIndex(e => e.Email, "UQ__Clientes__A9D10534B9479A20").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marcas__D5B1CDEBD9DA2EC7");

            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83C1EA1AA2");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK__Productos__Marca__3E52440B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE79842BC2518");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A197CEB3C40").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pasword).HasMaxLength(255);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__5B41514CEA50E57E");

            entity.Property(e => e.VentaId).HasColumnName("VentaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Ventas__ClienteI__44FF419A");

            entity.HasOne(d => d.Producto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Ventas__Producto__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

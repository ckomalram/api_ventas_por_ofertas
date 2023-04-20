using api_ventas_por_oferta.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace api_ventas_por_oferta.Core.Context;

public class BienesContext : DbContext
{
    public BienesContext(DbContextOptions<BienesContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Visita> Visitas { get; set; }
    public DbSet<Auto> Autos { get; set; }
    public DbSet<Inmueble> Inmuebles { get; set; }
    public DbSet<Patio> Patios { get; set; }

    //TODO: Usuarios    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Step#1 
        //** --Conf propiedades

        modelBuilder.Entity<Auto>(auto =>
        {
            auto.Property(a => a.Precio).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Inmueble>(inmu =>
        {
            inmu.Property(i => i.Precio).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Oferta>(oferta =>
        {
            oferta.Property(o => o.Monto).HasColumnType("decimal(18,2)");
        });


        //Step#2
        //--Relaciones


        // Configuración de la relación Cliente-Visita
        // modelBuilder.Entity<Cliente>()
        //     .HasMany(c => c.Visitas)
        //     .WithOne(v => v.Cliente)
        //     .HasForeignKey(v => v.ClienteId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Configuración de la relación Cliente-Oferta
        // modelBuilder.Entity<Cliente>()
        //     .HasMany(c => c.Ofertas)
        //     .WithOne(o => o.Cliente)
        //     .HasForeignKey(o => o.ClienteId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Configuración de la relación Inmueble-Oferta
        // modelBuilder.Entity<Inmueble>()
        //     .HasMany(i => i.Ofertas)
        //     .WithOne(o => o.Inmueble)
        //     .HasForeignKey(o => o.InmuebleId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Configuración de la relación Auto-Oferta
        // modelBuilder.Entity<Auto>()
        //     .HasMany(a => a.Ofertas)
        //     .WithOne(o => o.Auto)
        //     .HasForeignKey(o => o.AutoId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Configuración de la relación Auto-Visita
        // modelBuilder.Entity<Auto>()
        //     .HasMany(a => a.Visitas)
        //     .WithOne(v => v.Auto)
        //     .HasForeignKey(v => v.AutoId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Configuración de la relación Auto-Patio

        modelBuilder.Entity<Auto>()
        .HasOne(a => a.Patio)
        .WithMany(p => p.Autos)
        .HasForeignKey(a => a.PatioId);


        // Configuración de la relación Patio-Visita
        // modelBuilder.Entity<Patio>()
        //     .HasMany(p => p.Visitas)
        //     .WithOne(v => v.Patio)
        //     .HasForeignKey(v => v.PatioId);

        // TODO: Configuración de la relación Patio-Usuario
        // modelBuilder.Entity<Patio>()
        //     .HasMany(p => p.Usuarios)
        //     .WithOne(u => u.Patio)
        //     .HasForeignKey(u => u.PatioId)
        //     .OnDelete(DeleteBehavior.Cascade);
    }
}
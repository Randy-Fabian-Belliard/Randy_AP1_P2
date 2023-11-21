using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Ventas> Ventas { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Clientes>().HasData(new List<Clientes>()
        {
            new Clientes() {ClienteId = 1, Nombres = "FERRETERIA GAMA" ,},
            new Clientes() {ClienteId = 2, Nombres = "AVALON DISCO" ,},
            new Clientes() {ClienteId = 3, Nombres = "PRESTAMOS CEFIPROD" ,},

        });

                modelBuilder.Entity<Ventas>().HasData(new List<Ventas>()
        {
            new Ventas() {VentaId = 1, Fecha = new DateTime(2020, 09, 01), ClienteId = 1, Monto = 1000, Balance = 1000 ,},
            new Ventas() { VentaId = 2, Fecha = new DateTime(2020, 10, 01), ClienteId = 1, Monto = 900, Balance = 800 ,},
            new Ventas() { VentaId = 3, Fecha = new DateTime(2020, 09, 01), ClienteId = 2, Monto = 2000, Balance = 2000 ,},
            new Ventas() {VentaId = 4, Fecha = new DateTime(2020, 10, 01), ClienteId = 2, Monto = 1900, Balance = 1800 ,},
            new Ventas() {VentaId = 5, Fecha = new DateTime(2020, 09, 01), ClienteId = 3, Monto = 3000, Balance = 3000 ,},
            new Ventas() { VentaId = 6, Fecha = new DateTime(2020, 10, 01), ClienteId = 3, Monto = 2900, Balance = 1900 ,},

        });
    }

       public DbSet<Cobros> Cobros { get; set; } = default!;

    

}


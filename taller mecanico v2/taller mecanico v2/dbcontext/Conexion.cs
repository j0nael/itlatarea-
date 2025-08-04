using Microsoft.EntityFrameworkCore;
namespace taller_mecanico_v2.dbcontext;
public class Conexion : DbContext
{
    public Conexion() { } 
    public Conexion(DbContextOptions<Conexion> options) : base(options) { }

    public DbSet<Repuesto> Repuestos { get; set; }
    public DbSet<Mecanico> Mecanicos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reparacion> Reparaciones { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Factura> Facturas{ get; set; }

    public DbSet<Venta> Ventas{ get; set; }

    public DbSet<Vendedor> Vendedores{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=Mecanico;server=(local);TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehiculo>()
            .HasOne(v => v.Cliente)
            .WithMany(c => c.Vehiculos)
            .HasForeignKey(v => v.IdCliente);

        modelBuilder.Entity<Reparacion>()
            .HasOne(r => r.Vehiculo)
            .WithMany(v => v.Reparaciones)
            .HasForeignKey(r => r.PlacaVehiculo);

        modelBuilder.Entity<Reparacion>()
            .HasOne(r => r.Mecanico)
            .WithMany(m => m.Reparaciones)
            .HasForeignKey(r => r.IdMecanico);
    }
}

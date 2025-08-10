using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;

public class RepuestoService
{
    public static void VerHistorialRepuestos()
    {
        using var db = new Conexion();

        var repuestos = db.Repuestos.ToList();

        if (!repuestos.Any())
        {
            Console.WriteLine("No hay repuestos registrados.");
            return;
        }

        Console.WriteLine("=== HISTORIAL DE REPUESTOS ===");

        foreach (var repuesto in repuestos)
        {
            var ventas = db.Ventas.Where(v => v.Repuesto.Id == repuesto.Id).ToList();
            int vendidos = ventas.Sum(v => v.Cantidad);
            double totalVendido = ventas.Sum(v => v.Total);
            double valorInventario = repuesto.Cantidad * repuesto.PrecioUnitario;

            Console.WriteLine($"\nRepuesto: {repuesto.Nombre}");
            Console.WriteLine($"- En Stock: {repuesto.Cantidad}");
            Console.WriteLine($"- Precio Unitario: {repuesto.PrecioUnitario}");
            Console.WriteLine($"- Precio por Mayor: {repuesto.PrecioPorMayor}");
            Console.WriteLine($"- Vendidos: {vendidos}");
            Console.WriteLine($"- Valor en Inventario: {valorInventario}");
            Console.WriteLine($"- Valor Total Vendido: {totalVendido}");
        }
    }

    public static void Agregar()
    {
        Console.Write("Nombre del repuesto: ");
        string nombre = Console.ReadLine();
        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Precio unitario: ");
        double precioUnitario = double.Parse(Console.ReadLine());
        Console.Write("Precio por mayor: ");
        double precioPorMayor = double.Parse(Console.ReadLine());

        var repuesto = new Repuesto(nombre, cantidad, precioUnitario, precioPorMayor);

        using var db = new Conexion();
        db.Repuestos.Add(repuesto);
        db.SaveChanges();

        Console.WriteLine("Repuesto agregado.");
    }

    public static void Ver()
    {
        using var db = new Conexion();
        var lista = db.Repuestos.ToList();

        foreach (var r in lista)
        {
            Console.WriteLine($"ID: {r.Id}, Nombre: {r.Nombre}, Cantidad: {r.Cantidad}, Precio Unitario: {r.PrecioUnitario}, Precio Por Mayor: {r.PrecioPorMayor}");
        }
    }

    public static void Actualizar()
    {
        Console.Write("ID de la reparación a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var r = db.Reparaciones.Find(id);

        if (r == null)
        {
            Console.WriteLine("Reparación no encontrada.");
            return;
        }

        Console.Write($"Descripción actual: {r.Descripcion}. Nueva descripción: ");
        string descripcion = Console.ReadLine();
        r.Descripcion = string.IsNullOrEmpty(descripcion) ? r.Descripcion : descripcion;

        Console.Write($"Fecha actual: {r.Fecha.ToShortDateString()}. Nueva fecha (yyyy-MM-dd): ");
        string fechaInput = Console.ReadLine();
        if (DateTime.TryParse(fechaInput, out DateTime nuevaFecha))
            r.Fecha = nuevaFecha;

        Console.Write($"Costo actual: {r.Costo}. Nuevo costo: ");
        string costoInput = Console.ReadLine();
        if (double.TryParse(costoInput, out double nuevoCosto))
            r.Costo = nuevoCosto;

        db.SaveChanges();
        Console.WriteLine("Reparación actualizada.");
    }




    public static void Eliminar()
    {
        Console.Write("ID del repuesto a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using var db = new Conexion();
        var r = db.Repuestos.Find(id);

        if (r == null)
        {
            Console.WriteLine("Repuesto no encontrado.");
            return;
        }

        db.Repuestos.Remove(r);
        db.SaveChanges();
        Console.WriteLine("Repuesto eliminado.");
    }
}

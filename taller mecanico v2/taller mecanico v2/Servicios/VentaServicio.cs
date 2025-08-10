using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;

public class VentaServicio
{
    public static void VerVentasFiltradas()
    {
        using var db = new Conexion();

        Console.WriteLine("Filtrar ventas por rango de fechas");

        Console.Write("Fecha inicio (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaInicio))
        {
            Console.WriteLine("Fecha inicio inválida.");
            return;
        }

        Console.Write("Fecha fin (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaFin))
        {
            Console.WriteLine("Fecha fin inválida.");
            return;
        }

        fechaFin = fechaFin.Date.AddDays(1).AddTicks(-1); 

        var ventas = db.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Vendedor)
            .Include(v => v.Repuesto)
            .Where(v => v.Fecha >= fechaInicio && v.Fecha <= fechaFin)
            .ToList();

        if (ventas.Count == 0)
        {
            Console.WriteLine("No se encontraron ventas para el rango de fechas seleccionado.");
            return;
        }

        foreach (var v in ventas)
        {
          double total = v.Repuesto.PrecioUnitario * v.Cantidad;
          Console.WriteLine($"ID: {v.Id} | Cliente: {v.Cliente.Nombre} | Vendedor: {v.Vendedor.Nombre} | Repuesto: {v.Repuesto.Nombre} | Cantidad: {v.Cantidad} | Total: {total} | Fecha: {v.Fecha:yyyy-MM-dd}");
        }
    }

    public static void Agregar()
    {
        using var db = new Conexion();

        Console.Write("ID del Cliente: ");
        int clienteId = int.Parse(Console.ReadLine());
        var cliente = db.Clientes.Find(clienteId);
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        Console.Write("ID del Vendedor: ");
        int vendedorId = int.Parse(Console.ReadLine());
        var vendedor = db.Vendedores.Find(vendedorId);
        if (vendedor == null)
        {
            Console.WriteLine("Vendedor no encontrado.");
            return;
        }

        Console.Write("ID del Repuesto: ");
        int repuestoId = int.Parse(Console.ReadLine());
        var repuesto = db.Repuestos.Find(repuestoId);
        if (repuesto == null)
        {
            Console.WriteLine("Repuesto no encontrado.");
            return;
        }

        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        var venta = new Venta
        {
            Cliente = cliente,
            Vendedor = vendedor,
            Repuesto = repuesto,
            Cantidad = cantidad,
            Fecha = DateTime.Now
        };

        db.Ventas.Add(venta);
        db.SaveChanges();

        double total = repuesto.PrecioUnitario * cantidad;

        Console.WriteLine("\n=== Venta registrada exitosamente ===");
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Vendedor: {vendedor.Nombre}");
        Console.WriteLine($"Repuesto: {repuesto.Nombre}");
        Console.WriteLine($"Cantidad: {cantidad}");
        Console.WriteLine($"Precio Unitario: {repuesto.PrecioUnitario}");
        Console.WriteLine($"Total a pagar: {total}");
        Console.WriteLine($"Fecha: {venta.Fecha}");
    }

    public static void Ver()
    {
        using var db = new Conexion();
        var ventas = db.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Vendedor)
            .Include(v => v.Repuesto)
            .ToList();

        foreach (var v in ventas)
        {
            double total = v.Repuesto.PrecioUnitario * v.Cantidad;
            Console.WriteLine($"ID: {v.Id} | Cliente: {v.Cliente.Nombre} | Vendedor: {v.Vendedor.Nombre} | Repuesto: {v.Repuesto.Nombre} | Cantidad: {v.Cantidad} | Precio: {v.Repuesto.PrecioUnitario} | Total: {total} | Fecha: {v.Fecha}");
        }
    }

    public static void VerPorId()
    {
        Console.Write("ID de la venta a mostrar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var venta = db.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Vendedor)
            .Include(v => v.Repuesto)
            .FirstOrDefault(v => v.Id == id);

        if (venta == null)
        {
            Console.WriteLine("Venta no encontrada.");
            return;
        }

        double total = venta.Repuesto.PrecioUnitario * venta.Cantidad;

        Console.WriteLine($"ID: {venta.Id}");
        Console.WriteLine($"Cliente: {venta.Cliente.Nombre}");
        Console.WriteLine($"Vendedor: {venta.Vendedor.Nombre}");
        Console.WriteLine($"Repuesto: {venta.Repuesto.Nombre}");
        Console.WriteLine($"Cantidad: {venta.Cantidad}");
        Console.WriteLine($"Precio Unitario: {venta.Repuesto.PrecioUnitario}");
        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Fecha: {venta.Fecha}");
    }


    public static void Actualizar()
    {
        Console.Write("ID de la venta a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var venta = db.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Vendedor)
            .Include(v => v.Repuesto)
            .FirstOrDefault(v => v.Id == id);

        if (venta == null)
        {
            Console.WriteLine("Venta no encontrada.");
            return;
        }

        Console.WriteLine($"Cliente actual: {venta.Cliente.Nombre} (ID: {venta.Cliente.Id})");
        Console.Write("Nuevo ID de cliente (enter para no cambiar): ");
        string clienteInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(clienteInput) && int.TryParse(clienteInput, out int nuevoClienteId))
        {
            var nuevoCliente = db.Clientes.Find(nuevoClienteId);
            if (nuevoCliente != null)
                venta.Cliente = nuevoCliente;
            else
                Console.WriteLine("Cliente no encontrado. No se actualizó.");
        }

        Console.WriteLine($"Vendedor actual: {venta.Vendedor.Nombre} (ID: {venta.Vendedor.Id})");
        Console.Write("Nuevo ID de vendedor (enter para no cambiar): ");
        string vendedorInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(vendedorInput) && int.TryParse(vendedorInput, out int nuevoVendedorId))
        {
            var nuevoVendedor = db.Vendedores.Find(nuevoVendedorId);
            if (nuevoVendedor != null)
                venta.Vendedor = nuevoVendedor;
            else
                Console.WriteLine("Vendedor no encontrado. No se actualizó.");
        }

        Console.WriteLine($"Repuesto actual: {venta.Repuesto.Nombre} (ID: {venta.Repuesto.Id})");
        Console.Write("Nuevo ID de repuesto (enter para no cambiar): ");
        string repuestoInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(repuestoInput) && int.TryParse(repuestoInput, out int nuevoRepuestoId))
        {
            var nuevoRepuesto = db.Repuestos.Find(nuevoRepuestoId);
            if (nuevoRepuesto != null)
                venta.Repuesto = nuevoRepuesto;
            else
                Console.WriteLine("Repuesto no encontrado. No se actualizó.");
        }

        Console.Write($"Cantidad actual: {venta.Cantidad}. Nueva cantidad: ");
        string cantidadInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(cantidadInput) && int.TryParse(cantidadInput, out int nuevaCantidad))
        {
            venta.Cantidad = nuevaCantidad;
        }

        db.SaveChanges();
        Console.WriteLine("Venta actualizada.");
    }

    public static void Eliminar()
    {
        Console.Write("ID de la venta a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var venta = db.Ventas.Find(id);

        if (venta == null)
        {
            Console.WriteLine("Venta no encontrada.");
            return;
        }

        db.Ventas.Remove(venta);
        db.SaveChanges();
        Console.WriteLine("Venta eliminada.");
    }
}
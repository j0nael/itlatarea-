using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;

public class ReparacionService
{
    public static void Agregar()
    {
        Console.Write("Placa del vehículo: ");
        string placa = Console.ReadLine();
        Console.Write("ID del mecánico: ");
        int idMecanico = int.Parse(Console.ReadLine());
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();
        Console.Write("Costo: ");
        double costo = double.Parse(Console.ReadLine());
        Console.Write("Fecha entrada (yyyy-MM-dd): ");
        DateTime fecha = DateTime.Now;

        var reparacion = new Reparacion(0, placa, idMecanico, descripcion, costo, fecha);

        using var db = new Conexion();
        db.Reparaciones.Add(reparacion);
        db.SaveChanges();

        Console.WriteLine("Reparación agregada.");
    }

    public static void Ver()
    {
        using var db = new Conexion();
        var lista = db.Reparaciones.ToList();

        foreach (var r in lista)
        {
            Console.WriteLine($"ID: {r.Id}, Placa: {r.PlacaVehiculo}, Mecánico: {r.IdMecanico}, Descripción: {r.Descripcion}, Costo: {r.Costo}, Fecha: {r.Fecha.ToShortDateString()}");
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

        Console.Write($"Costo actual: {r.Costo}. Nuevo costo: ");
        string costoInput = Console.ReadLine();
        r.Costo = double.TryParse(costoInput, out double nuevoCosto) ? nuevoCosto : r.Costo;

        Console.Write($"Fecha actual: {r.Fecha:yyyy-MM-dd}. Nueva fecha (yyyy-MM-dd): ");
        string fechaInput = Console.ReadLine();
        r.Fecha = DateTime.TryParse(fechaInput, out DateTime nuevaFecha) ? nuevaFecha : r.Fecha;

        db.SaveChanges();
        Console.WriteLine("Reparación actualizada.");
    }

    public static void Eliminar()
    {
        Console.Write("ID de la reparación a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using var db = new Conexion();
        var r = db.Reparaciones.Find(id);

        if (r == null)
        {
            Console.WriteLine("No encontrada.");
            return;
        }

        db.Reparaciones.Remove(r);
        db.SaveChanges();
        Console.WriteLine("Reparación eliminada.");
    }
}

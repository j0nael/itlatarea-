using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;

public class VehiculoService
{
    public static void Agregar()
    {
        Console.Write("Placa: ");
        string placa = Console.ReadLine();
        Console.Write("Marca: ");
        string marca = Console.ReadLine();
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Año: ");
        int año = int.Parse(Console.ReadLine());
        Console.Write("ID Cliente: ");
        int idCliente = int.Parse(Console.ReadLine());

        var vehiculo = new Vehiculo(placa, marca, modelo, año, idCliente);

        using var db = new Conexion();
        db.Vehiculos.Add(vehiculo);
        db.SaveChanges();

        db.Vehiculos.Include(a => a.Cliente).First();

        Console.WriteLine("Vehículo agregado.");
    }

    public static void Ver()
    {
        using var db = new Conexion();
        var lista = db.Vehiculos.ToList();

        foreach (var v in lista)
        {
            Console.WriteLine($"Placa: {v.Placa}, Marca: {v.Marca}, Modelo: {v.Modelo}, Año: {v.Año}, ID Cliente: {v.IdCliente}");
        }
    }

    public static void Actualizar()
{
        Console.Write("ID del vehículo a actualizar (placa): ");
        string id = Console.ReadLine();

        using var db = new Conexion();
    var v = db.Vehiculos.Find(id);

    if (v == null)
    {
        Console.WriteLine("Vehículo no encontrado.");
        return;
    }

    Console.Write($"Placa actual ({v.Placa}). Nueva placa: ");
    string placa = Console.ReadLine();
    v.Placa = string.IsNullOrEmpty(placa) ? v.Placa : placa;

    Console.Write($"Marca actual ({v.Marca}). Nueva marca: ");
    string marca = Console.ReadLine();
    v.Marca = string.IsNullOrEmpty(marca) ? v.Marca : marca;

    Console.Write($"Modelo actual ({v.Modelo}). Nuevo modelo: ");
    string modelo = Console.ReadLine();
    v.Modelo = string.IsNullOrEmpty(modelo) ? v.Modelo : modelo;

        Console.Write($"Año actual: {v.Año}. Nuevo año: ");
        string anio = Console.ReadLine();
        v.Año = int.TryParse(anio, out int nuevoAnio) ? nuevoAnio : v.Año;


        db.SaveChanges();
    Console.WriteLine("Vehículo actualizado.");
}



    public static void Eliminar()
    {
        Console.Write("ID del vehículo a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using var db = new Conexion();
        var vehiculo = db.Vehiculos.Find(id);

        if (vehiculo == null)
        {
            Console.WriteLine("Vehículo no encontrado.");
            return;
        }

        db.Vehiculos.Remove(vehiculo);
        db.SaveChanges();
        Console.WriteLine("Vehículo eliminado.");
    }
}


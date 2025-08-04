using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;

public class VendedorServicio
{
    public static void Agregar()
    {
        Console.Write("Nombre del vendedor: ");
        string nombre = Console.ReadLine();

        var vendedor = new Vendedor { Nombre = nombre };

        using var db = new Conexion();
        db.Vendedores.Add(vendedor);
        db.SaveChanges();

        Console.WriteLine("Vendedor agregado.");
    }

    public static void Ver()
    {
        using var db = new Conexion();
        var vendedores = db.Vendedores.ToList();

        foreach (var v in vendedores)
        {
            Console.WriteLine($"ID: {v.Id}, Nombre: {v.Nombre}");
        }
    }

    public static void Actualizar()
    {
        Console.Write("ID del vendedor a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var vendedor = db.Vendedores.Find(id);

        if (vendedor == null)
        {
            Console.WriteLine("Vendedor no encontrado.");
            return;
        }

        Console.Write($"Nombre actual: {vendedor.Nombre}. Nuevo nombre: ");
        string nombre = Console.ReadLine();
        vendedor.Nombre = string.IsNullOrEmpty(nombre) ? vendedor.Nombre : nombre;

        db.SaveChanges();
        Console.WriteLine("Vendedor actualizado.");
    }

    public static void Eliminar()
    {
        Console.Write("ID del vendedor a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var vendedor = db.Vendedores.Find(id);

        if (vendedor == null)
        {
            Console.WriteLine("Vendedor no encontrado.");
            return;
        }

        db.Vendedores.Remove(vendedor);
        db.SaveChanges();
        Console.WriteLine("Vendedor eliminado.");
    }
}

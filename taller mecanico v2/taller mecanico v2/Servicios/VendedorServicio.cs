using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;
using taller_mecanico_v2.Migrations;

public class VendedorServicio
{
    public static void Agregar()
    {
        Console.Write("Nombre del vendedor: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellidoi del vendedor: ");
        string apellido = Console.ReadLine();
        Console.Write("Correo del vendedor: ");
        string correo = Console.ReadLine();
        Console.Write("Telefono del vendedor: ");
        string telefono = Console.ReadLine();
        var vendedor = new Vendedor { Nombre = nombre,Apellido=apellido,Correo=correo,Telefono=telefono }
        ;


        using var db = new Conexion();
        db.Vendedores.Add(vendedor);
        db.SaveChanges();

        Console.WriteLine("Vendedor agregado.");
    }

    public static void VerTodos()
    {
        using var db = new Conexion();
        var vendedores = db.Vendedores.ToList();

        foreach (var v in vendedores)
        {
            Console.WriteLine($"ID: {v.Id}, Nombre: {v.Nombre},Apellido : {v.Apellido},Correo :{v.Correo},Telefono:{v.Telefono}");
        }
    }

    public static void VerPorId()
    {
        using var conexion = new Conexion(new DbContextOptionsBuilder<Conexion>().Options);

        Console.Write("Ingrese el ID del vendedor a consultar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var vendedor = conexion.Vendedores.Find(id);
            if (vendedor != null)
            {
                Console.WriteLine("=== Información del Vendedor ===");
                Console.WriteLine($"ID: {vendedor.Id}");
                Console.WriteLine($"Nombre: {vendedor.Nombre}");
                Console.WriteLine($"Telefono: {vendedor.Apellido}");
                Console.WriteLine($"Correo: {vendedor.Correo}");
                Console.WriteLine($"Telefono: {vendedor.Telefono}");

            }
            else
            {
                Console.WriteLine("`vendedor no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
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
        Console.Write($"Nombre actual: {vendedor.Apellido}. Nuevo apellido: ");
        string apellido = Console.ReadLine();
        vendedor.Apellido = string.IsNullOrEmpty(apellido) ? vendedor.Apellido : apellido;
        Console.Write($"Nombre actual: {vendedor.Correo}. Nuevo correo: ");
        string correo = Console.ReadLine();
        vendedor.Correo = string.IsNullOrEmpty(correo) ? vendedor.Correo : correo;
        Console.Write($"Nombre actual: {vendedor.Telefono}. Nuevo telefono: ");
        string telefono = Console.ReadLine();
        vendedor.Telefono = string.IsNullOrEmpty(telefono) ? vendedor.Telefono : telefono;


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

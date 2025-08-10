using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using taller_mecanico_v2.dbcontext;

public class ClienteService
{

    public static void VerPorId()
    {
        using var conexion = new Conexion(new DbContextOptionsBuilder<Conexion>().Options);

        Console.Write("Ingrese el ID del cliente a consultar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var cliente = conexion.Clientes.Find(id);
            if (cliente != null)
            {
                Console.WriteLine("=== Información del Mecánico ===");
                Console.WriteLine($"ID: {cliente.Id}");
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Telefono: {cliente.Apellido}");
                Console.WriteLine($"Correo: {cliente.Correo}");
                Console.WriteLine($"Telefono: {cliente.Telefono}");
                     
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }


    public static void Agregar()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Correo: ");
        string correo = Console.ReadLine();


        var cliente = new Cliente { Nombre = nombre, Telefono = telefono, Correo = correo,Apellido=apellido };

        using var db = new Conexion();
        db.Clientes.Add(cliente);
        db.SaveChanges();

        Console.WriteLine("Cliente agregado.");
    }

    public static void Ver()
    {
        try
        {
            using var db = new Conexion();
            var clientes = db.Clientes.ToList();

            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Apellido{c.Apellido},Tel: {c.Telefono}, Correo: {c.Correo}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }

    }

    public static void Actualizar()
    {
        Console.Write("ID del cliente a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        using var db = new Conexion();
        var cliente = db.Clientes.Find(id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        Console.Write($"Nombre actual: {cliente.Nombre}. Nuevo nombre: ");
        string nombre = Console.ReadLine();
        cliente.Nombre = string.IsNullOrEmpty(nombre) ? cliente.Nombre : nombre;

        Console.Write($"Nombre actual: {cliente.Apellido}. Nuevo apellido: ");
        string apellido = Console.ReadLine();
        cliente.Apellido = string.IsNullOrEmpty(apellido) ? cliente.Apellido : apellido;

        Console.Write($"Teléfono actual: {cliente.Telefono}. Nuevo teléfono: ");
        string telefono = Console.ReadLine();
        cliente.Telefono = string.IsNullOrEmpty(telefono) ? cliente.Telefono : telefono;

        Console.Write($"Correo actual: {cliente.Correo}. Nuevo correo: ");
        string correo = Console.ReadLine();
        cliente.Correo = string.IsNullOrEmpty(correo) ? cliente.Correo : correo;

        db.SaveChanges();
        Console.WriteLine("Cliente actualizado.");
    }


    public static void Eliminar()
    {
        Console.Write("ID del cliente a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using var db = new Conexion();
        var cliente = db.Clientes.Find(id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        db.Clientes.Remove(cliente);
        db.SaveChanges();
        Console.WriteLine("Cliente eliminado.");
    }
}

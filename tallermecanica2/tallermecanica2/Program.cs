using System;
using System.Linq;
using TallerMecanico.Modelos;

namespace TallerMecanico.DTB
{
    public class ClienteDTB
    {
        public static void AgregarCliente()
        {
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();

            Console.Write("Correo: ");
            var correo = Console.ReadLine();

            Console.Write("Teléfono: ");
            var telefono = Console.ReadLine();

            using (var db = new TallerDbContext())
            {
                var cliente = new Cliente { Nombre = nombre, Correo = correo, Telefono = telefono };
                db.Clientes.Add(cliente);
                db.SaveChanges();
                Console.WriteLine("✅ Cliente agregado correctamente.");
            }
        }

        public static void VerClientes()
        {
            using (var db = new TallerDbContext())
            {
                var clientes = db.Clientes.ToList();
                Console.WriteLine("==== Lista de Clientes ====");
                foreach (var c in clientes)
                {
                    Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Correo: {c.Correo}, Tel: {c.Telefono}");
                }
            }
        }

        public static void EditarCliente()
        {
            Console.Write("Ingrese el ID del cliente a editar: ");
            int id = int.Parse(Console.ReadLine());

            using (var db = new TallerDbContext())
            {
                var cliente = db.Clientes.Find(id);
                if (cliente == null)
                {
                    Console.WriteLine("❌ Cliente no encontrado.");
                    return;
                }

                Console.WriteLine("¿Qué desea editar?");
                Console.WriteLine("1. Nombre");
                Console.WriteLine("2. Correo");
                Console.WriteLine("3. Teléfono");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nuevo nombre: ");
                        cliente.Nombre = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Nuevo correo: ");
                        cliente.Correo = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Nuevo teléfono: ");
                        cliente.Telefono = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        return;
                }

                db.SaveChanges();
                Console.WriteLine("✅ Cliente actualizado.");
            }
        }

        public static void EliminarCliente()
        {
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var db = new TallerDbContext())
            {
                var cliente = db.Clientes.Find(id);
                if (cliente == null)
                {
                    Console.WriteLine("❌ Cliente no encontrado.");
                    return;
                }

                db.Clientes.Remove(cliente);
                db.SaveChanges();
                Console.WriteLine("✅ Cliente eliminado.");
            }
        }
    }
}

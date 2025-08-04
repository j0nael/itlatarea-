using Microsoft.EntityFrameworkCore;
using taller_mecanico_v2.dbcontext;

namespace taller_mecanico_v2
{
    public class MecanicoService
    {
        public static void HistorialServicios()
        {
            using var db = new Conexion();

            Console.Write("Ingrese la fecha para buscar: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaFiltro))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            var historial = db.Reparaciones
                .Include(r => r.Mecanico)
                .Include(r => r.Vehiculo)
                .Where(r => r.Fecha.Date == fechaFiltro.Date)
                .ToList();

            if (historial.Count == 0)
            {
                Console.WriteLine("No se encontraron reparaciones para esa fecha.");
                return;
            }

            foreach (var r in historial)
            {
                Console.WriteLine($"ID Reparación: {r.Id} | Mecánico: {r.Mecanico.Nombre} | Vehículo: {r.Vehiculo.Marca} {r.Vehiculo.Modelo} | Descripción: {r.Descripcion} | Fecha: {r.Fecha:yyyy-MM-dd}");
            }
        }


        public static void Agregar()
        {
            Console.WriteLine("Ingrese el nombre del mecánico:");
            string nombre = Console.ReadLine() ?? "SinNombre";

            Console.WriteLine("Ingrese la especialidad del mecánico:");
            string especialidad = Console.ReadLine() ?? "SinEspecialidad";

            Mecanico mecanico = new Mecanico(nombre, especialidad);

            using var conexion = new Conexion(new DbContextOptionsBuilder<Conexion>().Options);
            conexion.Mecanicos.Add(mecanico);
            conexion.SaveChanges();
           
            Console.WriteLine("Mecánico agregado correctamente.");
        }

        public static void VerTodos()
        {
            using var conexion = new Conexion(new DbContextOptionsBuilder<Conexion>().Options);
            var mecanicos = conexion.Mecanicos.ToList();

            Console.WriteLine("=== Lista de Mecánicos ===");
            foreach (var m in mecanicos)
            {
                Console.WriteLine($"ID: {m.Id}, Nombre: {m.Nombre}, Especialidad: {m.Especialidad}");
            }
        }

        public static void VerPorId()
        {
            using var conexion = new Conexion(new DbContextOptionsBuilder<Conexion>().Options);

            Console.Write("Ingrese el ID del mecánico a consultar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var mecanico = conexion.Mecanicos.Find(id);
                if (mecanico != null)
                {
                    Console.WriteLine("=== Información del Mecánico ===");
                    Console.WriteLine($"ID: {mecanico.Id}");
                    Console.WriteLine($"Nombre: {mecanico.Nombre}");
                    Console.WriteLine($"Especialidad: {mecanico.Especialidad}");
                }
                else
                {
                    Console.WriteLine("Mecánico no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }


        public static void Actualizar()
        {
            Console.Write("ID del mecánico a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            using var db = new Conexion();
            var m = db.Mecanicos.Find(id);

            if (m == null)
            {
                Console.WriteLine("Mecánico no encontrado.");
                return;
            }

            Console.Write($"Nombre actual: {m.Nombre}. Nuevo nombre: ");
            string nombre = Console.ReadLine();
            m.Nombre = string.IsNullOrEmpty(nombre) ? m.Nombre : nombre;

            Console.Write($"Especialidad actual: {m.Especialidad}. Nueva especialidad: ");
            string especialidad = Console.ReadLine();
            m.Especialidad = string.IsNullOrEmpty(especialidad) ? m.Especialidad : especialidad;

            db.SaveChanges();
            Console.WriteLine("Mecánico actualizado.");
        }



        public static void Eliminar()
        {
            using var conexion = new Conexion(new DbContextOptionsBuilder<Conexion>().Options);
            Console.Write("Ingrese el ID del mecánico a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var mecanico = conexion.Mecanicos.Find(id);
                if (mecanico != null)
                {
                    conexion.Mecanicos.Remove(mecanico);
                    conexion.SaveChanges();
                    Console.WriteLine("Mecánico eliminado.");
                }
                else
                {
                    Console.WriteLine("Mecánico no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }




}


using System;
using taller_mecanico_v2;

class Program
{
    static void Main(string[] args)
    {
        string opcionGeneral;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Gestión de Mecánicos");
            Console.WriteLine("2. Gestión de Clientes");
            Console.WriteLine("3. Gestión de Vehículos");
            Console.WriteLine("4. Gestión de Reparaciones");
            Console.WriteLine("5. Gestión de Repuestos");
            Console.WriteLine("6. Gestión de Ventas");
            Console.WriteLine("7. Gestión de Vendedores");
            Console.WriteLine("8. Historial de Servicios"); 
            Console.Write("Seleccione una opción: ");
            opcionGeneral = Console.ReadLine();
           

            switch (opcionGeneral)
            {
                case "1":
                    Console.WriteLine("1. Agregar mecánico");
                    Console.WriteLine("2. Ver todos los mecánicos");
                    Console.WriteLine("3. Ver mecánico por ID");
                    Console.WriteLine("4. Actualizar mecánico");
                    Console.WriteLine("5. Eliminar mecánico");
                    string opcionMecanico = Console.ReadLine();
                    switch (opcionMecanico)
                    {
                        case "1": MecanicoService.Agregar(); break;
                        case "2": MecanicoService.VerTodos(); break;
                        case "3": MecanicoService.VerPorId(); break;
                        case "4": MecanicoService.Actualizar(); break;
                        case "5": MecanicoService.Eliminar(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE CLIENTES ===");
                    Console.WriteLine("1. Agregar cliente");
                    Console.WriteLine("2. Ver clientes");
                    Console.WriteLine("3. Actualizar cliente");
                    Console.WriteLine("4. Eliminar cliente");
                    Console.Write("Seleccione una opción: ");
                    string opcionCliente = Console.ReadLine();
                    switch (opcionCliente)
                    {
                        case "1": ClienteService.Agregar(); break;
                        case "2": ClienteService.Ver(); break;
                        case "3": ClienteService.Actualizar(); break;
                        case "4": ClienteService.Eliminar(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VEHÍCULOS ===");
                    Console.WriteLine("1. Agregar vehículo");
                    Console.WriteLine("2. Ver vehículos");
                    Console.WriteLine("3. Actualizar vehículo");
                    Console.WriteLine("4. Eliminar vehículo");
                    Console.Write("Seleccione una opción: ");
                    string opcionVehiculo = Console.ReadLine();
                    switch (opcionVehiculo)
                    {
                        case "1": VehiculoService.Agregar(); break;
                        case "2": VehiculoService.Ver(); break;
                        case "3": VehiculoService.Actualizar(); break;
                        case "4": VehiculoService.Eliminar(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE REPARACIONES ===");
                    Console.WriteLine("1. Agregar reparación");
                    Console.WriteLine("2. Ver reparaciones");
                    Console.WriteLine("3. Actualizar reparación");
                    Console.WriteLine("4. Eliminar reparación");
                    Console.Write("Seleccione una opción: ");
                    string opcionReparacion = Console.ReadLine();
                    switch (opcionReparacion)
                    {
                        case "1": ReparacionService.Agregar(); break;
                        case "2": ReparacionService.Ver(); break;
                        case "3": ReparacionService.Actualizar(); break;
                        case "4": ReparacionService.Eliminar(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE REPUESTOS ===");
                    Console.WriteLine("1. Agregar repuesto");
                    Console.WriteLine("2. Ver repuestos");
                    Console.WriteLine("3. Actualizar repuesto");
                    Console.WriteLine("4. Eliminar repuesto");
                    Console.WriteLine("5. Ver historial de repuestos");
                    Console.Write("Seleccione una opción: ");
                    string opcionRepuesto = Console.ReadLine();
                    switch (opcionRepuesto)
                    {
                        case "1": RepuestoService.Agregar(); break;
                        case "2": RepuestoService.Ver(); break;
                        case "3": RepuestoService.Actualizar(); break;
                        case "4": RepuestoService.Eliminar(); break;
                        case "5": RepuestoService.VerHistorialRepuestos(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VENTAS ===");
                    Console.WriteLine("1. Registrar venta");
                    Console.WriteLine("2. Ver todas las ventas");
                    Console.WriteLine("3. Ver venta por ID");
                    Console.WriteLine("4. Actualizar venta");
                    Console.WriteLine("5. Eliminar venta");
                    Console.WriteLine("6. Ver ventas filtradas (por cliente o fecha)");
                    Console.Write("Seleccione una opción: ");
                    string opcionVenta = Console.ReadLine();
                    switch (opcionVenta)
                    {
                        case "1": VentaServicio.Agregar(); break;
                        case "2": VentaServicio.Ver(); break;
                        case "3": VentaServicio.VerPorId(); break;
                        case "4": VentaServicio.Actualizar(); break;
                        case "5": VentaServicio.Eliminar(); break;
                        case "6": VentaServicio.VerVentasFiltradas(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VENDEDORES ===");
                    Console.WriteLine("1. Agregar vendedor");
                    Console.WriteLine("2. Ver vendedores");
                    Console.WriteLine("3. Actualizar vendedor");
                    Console.WriteLine("4. Eliminar vendedor");
                    Console.Write("Seleccione una opción: ");
                    string opcionVendedor = Console.ReadLine();
                    switch (opcionVendedor)
                    {
                        case "1": VendedorServicio.Agregar(); break;
                        case "2": VendedorServicio.Ver(); break;
                        case "3": VendedorServicio.Actualizar(); break;
                        case "4": VendedorServicio.Eliminar(); break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "8":
                    MecanicoService.HistorialServicios(); break;

                case "0":
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (opcionGeneral != "0")
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcionGeneral != "0");
    }
}

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
                        case "1": try { MecanicoService.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { MecanicoService.VerTodos(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { MecanicoService.VerPorId(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { MecanicoService.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { MecanicoService.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE CLIENTES ===");
                    Console.WriteLine("1. Agregar cliente");
                    Console.WriteLine("2. Ver clientes");
                    Console.WriteLine("3. Ver por id");
                    Console.WriteLine("4. Actualizar cliente");
                    Console.WriteLine("5. Eliminar cliente");
                    Console.Write("Seleccione una opción: ");
                    string opcionCliente = Console.ReadLine();
                    switch (opcionCliente)
                    {
                        case "1": try { ClienteService.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { ClienteService.Ver(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { ClienteService.VerPorId(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { ClienteService.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { ClienteService.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VEHÍCULOS ===");
                    Console.WriteLine("1. Agregar vehículo");
                    Console.WriteLine("2. Ver vehículos");
                    Console.WriteLine("3. Ver por placa");
                    Console.WriteLine("4. Actualizar vehículo");
                    Console.WriteLine("5. Eliminar vehículo");
                    Console.Write("Seleccione una opción: ");
                    string opcionVehiculo = Console.ReadLine();
                    switch (opcionVehiculo)
                    {
                        case "1": try { VehiculoService.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { VehiculoService.Ver(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { VehiculoService.VerPorplaca(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { VehiculoService.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { VehiculoService.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE REPARACIONES ===");
                    Console.WriteLine("1. Agregar reparación");
                    Console.WriteLine("2. Ver reparaciones");
                    Console.WriteLine("3. Filtrar por fechas");
                    Console.WriteLine("4. Actualizar reparación");
                    Console.WriteLine("5. Eliminar reparación");
                    Console.Write("Seleccione una opción: ");
                    string opcionReparacion = Console.ReadLine();
                    switch (opcionReparacion)
                    {
                        case "1": try { ReparacionService.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { ReparacionService.Ver(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { ReparacionService.FiltrarPorFecha(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { ReparacionService.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { ReparacionService.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
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
                        case "1": try { RepuestoService.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { RepuestoService.Ver(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { RepuestoService.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { RepuestoService.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { RepuestoService.VerHistorialRepuestos(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VENTAS ===");
                    Console.WriteLine("1. Registrar venta");
                    Console.WriteLine("2. Ver todas las ventas");
                    Console.WriteLine("3. Ver venta por ID");
                    Console.WriteLine("4. Ver ventas filtradas (por cliente o fecha)");
                    Console.WriteLine("5. Actualizar venta");
                    Console.WriteLine("6.Eliminar");
                    Console.Write("Seleccione una opción: ");
                    string opcionVenta = Console.ReadLine();
                    switch (opcionVenta)
                    {
                        case "1": try { VentaServicio.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { VentaServicio.Ver(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { VentaServicio.VerPorId(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { VentaServicio.VerVentasFiltradas(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { VentaServicio.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "6": try { VentaServicio.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;     
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
                        case "1": try { VendedorServicio.Agregar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { VendedorServicio.VerTodos(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { VendedorServicio.VerPorId(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { VendedorServicio.Actualizar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { VendedorServicio.Eliminar(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "8":
                    try { MecanicoService.HistorialServicios(); } catch (Exception ex) { Console.WriteLine(ex); }
                    break;

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

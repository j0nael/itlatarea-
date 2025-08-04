using System;
using System.ComponentModel.DataAnnotations;
public class Factura
{
    [Key]
    public int Id { get; set; }

    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; } 

    public DateTime Fecha { get; set; }

    public List<Venta> DetallesVenta { get; set; }

    public double Total
    {
        get
        {
            double total = 0;
            foreach (var venta in DetallesVenta)
            {
                total += venta.Total;
            }
            return total;
        }
    }

    public Factura()
    {
        DetallesVenta = new List<Venta>();
        Fecha = DateTime.Now;
    }

    public Factura(int id, Cliente cliente, Vendedor vendedor)
    {
        Id = id;
        Cliente = cliente;
        Vendedor = vendedor;
        Fecha = DateTime.Now;
        DetallesVenta = new List<Venta>();
    }

    public void AgregarVenta(Venta venta)
    {
        DetallesVenta.Add(venta);
    }

    public string MostrarFactura()
    {
        string detalle = $"--- FACTURA #{Id} ---\n" +
                         $"Fecha: {Fecha}\n" +
                         $"Cliente: {Cliente.Nombre}\n" +
                         $"Vendedor: {Vendedor.Nombre}\n\n" +
                         $"DETALLES:\n";

        foreach (var venta in DetallesVenta)
        {
            detalle += $"- {venta.Cantidad} x {venta.Repuesto.Nombre} @ {venta.Repuesto.PrecioUnitario:C} = {venta.Total:C}\n";
        }

        detalle += $"\nTOTAL: {Total:C}";

        return detalle;
    }
}

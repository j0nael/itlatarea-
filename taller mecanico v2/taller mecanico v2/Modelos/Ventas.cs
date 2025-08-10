using System;
using System.ComponentModel.DataAnnotations;

public class Venta
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Cliente Cliente { get; set; }

    [Required]
    public Vendedor Vendedor { get; set; }

    [Required]
    public Repuesto Repuesto { get; set; }

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    public double PrecioUnitario { get; set; } 

    public double Total => PrecioUnitario * Cantidad;

    public DateTime Fecha { get; set; }

    public Venta() { }

    public Venta(Cliente cliente, Vendedor vendedor, Repuesto repuesto, int cantidad)
    {
        Cliente = cliente;
        Vendedor = vendedor;
        Repuesto = repuesto;
        Cantidad = cantidad;
        PrecioUnitario = repuesto.PrecioUnitario; // Precio congelado al momento de la venta
        Fecha = DateTime.Now;

    }

    public string MostrarDetalle()
    {
        return $"VENTA #{Id} - {Fecha:dd/MM/yyyy HH:mm}\n" +
               $"Cliente: {Cliente.Nombre}\n" +
               $"Vendedor: {Vendedor.Nombre}\n" +
               $"Repuesto: {Repuesto.Nombre}\n" +
               $"Cantidad: {Cantidad}\n" +
               $"Precio Unitario: {PrecioUnitario:C}\n" +
               $"Total: {Total:C}";
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Repuesto
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int CantidadInicial { get; set; } // Cantidad cuando se agregó

    public int Cantidad { get; set; } // Stock actual

    public double PrecioUnitario { get; set; }

    public double PrecioPorMayor { get; set; }

    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    // Relación con ventas
    public List<Venta> Ventas { get; set; } = new();

    public Repuesto() { }

    public Repuesto(string nombre, int cantidad, double precioUnitario, double precioPorMayor)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        CantidadInicial = cantidad;
        PrecioUnitario = precioUnitario;
        PrecioPorMayor = precioPorMayor;
        FechaIngreso = DateTime.Now;
    }
}

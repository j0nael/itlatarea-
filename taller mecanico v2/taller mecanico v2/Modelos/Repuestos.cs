using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class SparePart
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }                 // Nombre

    public int InitialQuantity { get; set; }         // CantidadInicial (cantidad cuando se agregó)

    public int Quantity { get; set; }                // Cantidad (stock actual)

    public double UnitPrice { get; set; }            // PrecioUnitario

    public double WholesalePrice { get; set; }       // PrecioPorMayor

    public DateTime EntryDate { get; set; } = DateTime.Now; // FechaIngreso

    // Relationship with sales
    public List<Sale> Sales { get; set; } = new();   // Ventas

    public SparePart() { }

    public SparePart(string name, int quantity, double unitPrice, double wholesalePrice)
    {
        Name = name;
        Quantity = quantity;
        InitialQuantity = quantity;
        UnitPrice = unitPrice;
        WholesalePrice = wholesalePrice;
        EntryDate = DateTime.Now;
    }
}

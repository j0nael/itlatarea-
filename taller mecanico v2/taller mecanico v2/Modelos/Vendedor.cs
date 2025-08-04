using System;
using System.ComponentModel.DataAnnotations;

public class Vendedor
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Vendedor() { }

    public Vendedor(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}

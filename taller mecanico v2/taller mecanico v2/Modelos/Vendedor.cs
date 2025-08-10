using System;
using System.ComponentModel.DataAnnotations;

public class Vendedor
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
     public string Apellido { get; set; }
    public string Correo { get; set; }
public string Telefono { get; set; }
    public Vendedor() { }

    public Vendedor(int id, string nombre, string apellido, string correo, string telefono)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Correo = correo;
        this.Telefono = telefono;
    }
}

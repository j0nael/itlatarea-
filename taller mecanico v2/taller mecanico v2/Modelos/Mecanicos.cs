using System;
using System.ComponentModel.DataAnnotations;

public class Mecanico
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Especialidad { get; set; }

    public List<Reparacion> Reparaciones { get; set; }


    public Mecanico(string nombre, string especialidad)
    {
        this.Nombre=nombre;
        this.Especialidad=especialidad;
    }

    public Mecanico() { } 
}

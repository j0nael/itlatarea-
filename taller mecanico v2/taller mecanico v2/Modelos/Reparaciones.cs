using System;
using System.ComponentModel.DataAnnotations;

public class Reparacion
{
    [Key]
    public int Id { get; set; }
    public string PlacaVehiculo { get; set; }
    public int IdMecanico { get; set; }

    public string Descripcion { get; set; }
    public double Costo { get; set; }
    public DateTime Fecha { get; set; }
    public Vehiculo Vehiculo { get; set; }

   
    public Mecanico Mecanico { get; set; }


    public Reparacion() { }

    
    public Reparacion(int id, string placaVehiculo, int idMecanico, string descripcion, double costo, DateTime fecha)
    {
        this.Id = id;
        this.PlacaVehiculo = placaVehiculo;
        this.IdMecanico = idMecanico;
        this.Descripcion = descripcion;
        this.Costo = costo;
        this.Fecha = fecha;
    }
}

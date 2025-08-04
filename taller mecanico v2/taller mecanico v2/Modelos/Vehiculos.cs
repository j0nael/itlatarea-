using System;
using System.ComponentModel.DataAnnotations;

public class Vehiculo
{
    [Key]
  
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public int IdCliente { get; set; }

  
    public Cliente Cliente { get; set; }

    public List<Reparacion> Reparaciones { get; set; }

    public Vehiculo(string placa, string marca, string modelo, int año, int idCliente)
    {
        this.Placa = placa;
        this.Marca = marca;
        this.Modelo = modelo;
        this.Año = año;
        this.IdCliente = idCliente;
    }
}

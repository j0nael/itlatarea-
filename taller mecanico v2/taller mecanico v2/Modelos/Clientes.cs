using System;
using System.ComponentModel.DataAnnotations;

public class Cliente
    {

    [Key]
    public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
   
    public List<Vehiculo> Vehiculos { get; set; }
    public Cliente(int id, string nombre, string telefono, string correo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public Cliente() { }
    }

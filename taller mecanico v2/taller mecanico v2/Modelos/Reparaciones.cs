using System;
using System.ComponentModel.DataAnnotations;

public class Repair
{
    [Key]
    public int Id { get; set; }
    public string VehicleLicensePlate { get; set; } // PlacaVehiculo
    public int MechanicId { get; set; }              // IdMecanico

    public string Description { get; set; }         // Descripcion
    public double Cost { get; set; }                 // Costo
    public DateTime Date { get; set; }               // Fecha
    public Vehicle Vehicle { get; set; }             // Vehiculo

    public Mechanic Mechanic { get; set; }           // Mecanico

    public Repair() { }

    public Repair(int id, string vehicleLicensePlate, int mechanicId, string description, double cost, DateTime date)
    {
        this.Id = id;
        this.VehicleLicensePlate = vehicleLicensePlate;
        this.MechanicId = mechanicId;
        this.Description = description;
        this.Cost = cost;
        this.Date = date;
    }
}

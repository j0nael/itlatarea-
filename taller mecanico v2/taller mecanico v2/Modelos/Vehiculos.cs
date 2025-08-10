using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Vehicle
{
    [Key]
    public string LicensePlate { get; set; }       // Placa
    public string Brand { get; set; }              // Marca
    public string Model { get; set; }              // Modelo
    public int Year { get; set; }                  // Año
    public int CustomerId { get; set; }            // IdCliente

    public Customer Customer { get; set; }         // Cliente

    public List<Repair> Repairs { get; set; }      // Reparaciones

    public Vehicle(string licensePlate, string brand, string model, int year, int customerId)
    {
        this.LicensePlate = licensePlate;
        this.Brand = brand;
        this.Model = model;
        this.Year = year;
        this.CustomerId = customerId;
    }
}

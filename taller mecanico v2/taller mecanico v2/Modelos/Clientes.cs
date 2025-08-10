using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }      // Nombre
    public string LastName { get; set; }       // Apellido
    public string PhoneNumber { get; set; }    // Telefono
    public string Email { get; set; }          // Correo
    

    public List<Vehicle> Vehicles { get; set; } // Vehiculos

    public Customer(int id, string firstName, string phoneNumber, string email, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        this.LastName = lastName;
    }

    public Customer() { }
}

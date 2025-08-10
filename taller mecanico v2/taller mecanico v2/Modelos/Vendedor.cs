using System;
using System.ComponentModel.DataAnnotations;

public class Seller
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }   // Nombre
    public string LastName { get; set; }    // Apellido
    public string Email { get; set; }       // Correo
    public string PhoneNumber { get; set; } // Telefono

    public Seller() { }

    public Seller(int id, string firstName, string lastName, string email, string phoneNumber)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }
}

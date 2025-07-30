using System.ComponentModel.DataAnnotations;

namespace TallerMecanico.Modelos
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}

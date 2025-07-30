using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TallerMecanico.Modelos;

namespace TallerMecanico.DTB
{
    public class TallerDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Actualiza con tu cadena de conexión real
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TallerMecanicoDB;Trusted_Connection=True;");
        }
    }
}

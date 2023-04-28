using ApiCoreCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudPersonajes.Data
{
    public class PersonajesContext: DbContext
    {
        public PersonajesContext
           (DbContextOptions<PersonajesContext> options) :
           base(options)
        { }

        public DbSet<Personaje> Personajes { get; set; }
    }
}

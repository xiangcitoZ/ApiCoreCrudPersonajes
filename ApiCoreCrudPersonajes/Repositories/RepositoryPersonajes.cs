using ApiCoreCrudPersonajes.Data;
using ApiCoreCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await
                this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task InsertarPersonaje(int idpersonaje,
            string personaje, string imagen, int idserie)
        {
            Personaje pj = new Personaje();
            pj.IdPersonaje = idpersonaje;
            pj.Personajes = personaje;
            pj.Imagen = imagen;
            pj.IdSerie = idserie;   
            this.context.Personajes.Add(pj);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int idpersonaje,
            string personaje, string imagen, int idserie)
        {
            Personaje pj = await this.FindPersonajeAsync(idpersonaje);

            pj.Personajes = personaje;
            pj.Imagen = imagen;
            pj.IdSerie = idserie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            Personaje pj = await this.FindPersonajeAsync(idpersonaje);
            this.context.Personajes.Remove(pj);
            await this.context.SaveChangesAsync();
        }


    }
}

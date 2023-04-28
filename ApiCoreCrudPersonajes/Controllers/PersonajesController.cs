using ApiCoreCrudPersonajes.Models;
using ApiCoreCrudPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {

        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpGet("{idpersonaje}")]
        public async Task<ActionResult<Personaje>> FindDepartamento(int idpersonaje)
        {
            return await this.repo.FindPersonajeAsync(idpersonaje);
        }

        

        [HttpPost]
        public async Task<ActionResult>
         InsertDepartamento(Personaje personaje)
        {
            await this.repo.InsertarPersonaje
                (personaje.IdPersonaje, personaje.Personajes,
                personaje.Imagen, personaje.IdSerie);
            return Ok();
        }



        [HttpPost]
        [Route("[action]/{idpersonaje}/{personaje}/{imagen}/{idserie}")]
        public async Task<ActionResult>
            InsertarPersonaje(Personaje personaje)
        {
            await this.repo.InsertarPersonaje(personaje.IdPersonaje, personaje.Personajes,
                personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync(personaje.IdPersonaje, personaje.Personajes,
                personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete("{idpersonaje}")]
        public async Task<ActionResult> DeletePersonaje(int idpersonaje)
        {
            await this.repo.DeletePersonajeAsync(idpersonaje);
            return Ok();
        }
    }
}

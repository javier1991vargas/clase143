using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;
using MoviesAPI.Entidades;

namespace MoviesAPI.Controllers
{
    [ApiController]

    [Route("api/generos")]
    public class GeneroController : ControllerBase
    {
        private readonly ApplicatioBdContext context;
        private readonly IMapper mapper;

        public GeneroController(ApplicatioBdContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> get()
        {
            var i = await context.Generos.ToListAsync();
            var x= mapper.Map<List<GeneroDTO>>(i);
            return x;
        }

        [HttpGet("id:int",Name="obtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> get(int id)
        {
            var i = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if(i == null)
            {
                return NotFound();
            }

            var dtos = mapper.Map<GeneroDTO>(i);
            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var persona = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(persona);
            await context.SaveChangesAsync();
            var generodto = mapper.Map<GeneroDTO>(persona);
            return new CreatedAtRouteResult("obtenerGenero",new { id = generodto.Id }, generodto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var persona = mapper.Map<Genero>(generoCreacionDTO);
            persona.Id = id;
            context.Entry(persona).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Generos.AnyAsync(x => x.Id == id);


            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Genero() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();

        }

    }
}

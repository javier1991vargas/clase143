using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;
using MoviesAPI.Entidades;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicatioBdContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicatioBdContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> get()
        {
            var entidades = await context.Actores.ToListAsync();

            return mapper.Map<List<ActorDTO>>(entidades);
        }

        [HttpGet("id:int", Name = "obtenerActor")]
        public async Task<ActionResult<ActorDTO>> get(int id)
        {
            var entidad = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
            {
                return NoContent();
            }
            return mapper.Map<ActorDTO>(entidad);

        }

        [HttpPost]
        public async Task<ActionResult> post([FromForm] AutorCreacionDTO autorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(autorCreacionDTO);
            //await context.Actores.AddAsync(entidad);
            context.Add(entidad);
          // await context.SaveChangesAsync();
            var dto = mapper.Map<ActorDTO>(entidad);
            return new CreatedAtRouteResult("obtenerActor", new { id = entidad.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, [FromBody] AutorCreacionDTO autorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(autorCreacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Actores.AnyAsync(x => x.Id == id);


            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Actor() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();

        }
    }
}

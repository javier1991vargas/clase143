using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entidades;

namespace MoviesAPI
{
    public class ApplicatioBdContext : DbContext
    {
        public ApplicatioBdContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
    }
}

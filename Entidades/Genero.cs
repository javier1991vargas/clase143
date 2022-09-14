using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public String Nombre { get; set; }
    }
}

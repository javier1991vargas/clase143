using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class GeneroDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public String Nombre { get; set; }
    }
}

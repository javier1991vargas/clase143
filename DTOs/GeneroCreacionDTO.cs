using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public String Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PeliculaApp2.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nombre_Pelicula { get; set; }
        [Required]
        [StringLength(50)]
        public string? Genero { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Precio { get; set; }
    }
}

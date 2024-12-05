using System.ComponentModel.DataAnnotations;

namespace Pi3.Dtos
{
    public class AvaliacaoUpdateDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Comentario { get; set; }

        [Required]
        [Range(0, 5)]
        public double Nota { get; set; }

        [Required]
        public bool Spoiler { get; set; }
    }
}

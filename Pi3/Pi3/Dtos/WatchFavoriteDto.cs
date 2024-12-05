using System.ComponentModel.DataAnnotations;

namespace Pi3.Dtos
{
    public class WatchFavoriteDto
    {
        [Required]
        public string NomeFilme { get; set; }

        [Required]
        public int IdTmdb { get; set; }
    }
}

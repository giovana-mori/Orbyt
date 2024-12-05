using System.ComponentModel.DataAnnotations;

namespace Pi3.Dtos
{
    public class AlterarSenhaDto
    {
        [Required]
        public string Senha {  get; set; }

        [Required]
        public string SenhaConfimar { get; set; }
    }
}

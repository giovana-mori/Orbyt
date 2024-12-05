using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Mappers
{
    public static class AvaliacaoMapper
    {
        public static Avaliacao FromAvaliacaoDto(AvaliacaoCreateDto avaliacao)
        {
            return new Avaliacao
            {
                IdTmdb = avaliacao.IdTmdb,
                Comentario = avaliacao.Comentario,
                Nota = avaliacao.Nota,
                Spoiler = avaliacao.Spoiler
            };
        }
    }
}

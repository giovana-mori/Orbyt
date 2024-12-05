using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Mappers
{
    public static class WatchFavoriteMapper
    {
        public static WatchList toWatchListModel(this WatchFavoriteDto watchFavoriteDto)
        {

            return new WatchList
            {
                NomeFilme = watchFavoriteDto.NomeFilme,
                IdTmdb = watchFavoriteDto.IdTmdb
            };
        }

        public static Favorite ToFavoriteModel(this WatchFavoriteDto watchFavoriteDto)
        {
            return new Favorite
            {
                NomeFilme = watchFavoriteDto.NomeFilme,
                IdTmdb = watchFavoriteDto.IdTmdb
            };
        }
    }
}

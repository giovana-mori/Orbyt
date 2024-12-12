import React from "react";
import API from "../utils/API";

function BtnWatchlist({
  addOrDelete = false, id, title, onClick,
}) {
  const watchFavorite = {
    NomeFilme: title,
    IdTmdb: id,
  };
  const favoriteMovie = () => {
    API.post('/Usuarios/watch-list', watchFavorite).then(() => { alert("filme favoritado"); }).catch((error) => { console.log(error.response.data); });
  };
  return (
    <div>
      <button
        onClick={(e) => {
          e.stopPropagation();
          if (onClick) { favoriteMovie(); }
        }}
        type="button"
        className="bg-white p-1 rounded-full w-full text-center flex flex-row items-center justify-center max-w-44 font-semibold mx-auto gap-2"
      >
        {addOrDelete ? (
          <img className="w-4" src="/img/add_icon.svg" alt="add watchlist" />
        ) : (
          <img className="w-4" src="/img/delete_icon.svg" alt="add watchlist" />
        )}
        {addOrDelete ? "Adicionar" : "Remover"}
      </button>
    </div>
  );
}
export default BtnWatchlist;

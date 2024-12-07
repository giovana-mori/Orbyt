import React from "react";

function BtnWatchlist({ addOrDelete = false }) {
  return (
    <div>
      <button
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

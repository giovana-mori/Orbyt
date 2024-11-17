import React from "react";
import BtnWatchlist from "./btnwachlist";

function ItemFilme() {
  return (
    <div className="flex flex-col bg-fundocards max-w-xs border border-bordagray rounded-xl overflow-hidden gap-2 pb-3">
      <div>
        <img src="img/cartaz_coringa.jpg" alt="" />
      </div>
      <div className="flex flex-row items-center justify-center gap-2">
        <h2 className="text-lg text-white font-medium">Título</h2>
        <span className="min-w-16 font-semibold bg-white text-center bg-opacity-80 rounded-lg">5,0</span>
      </div>
      <div>
        <BtnWatchlist />
      </div>
    </div>
  );
}
export default ItemFilme;

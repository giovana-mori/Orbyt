/* eslint-disable */
import React, { useEffect, useState } from "react";
import BtnWatchlist from "./btnwachlist";

function ItemFilme() {
  const [addMovie, setAddMovie] = useState(true);

  useEffect(() => {
    setAddMovie(false);
  }, []);

  return (
    <div className="flex flex-col bg-fundocards max-w-xs border border-bordagray rounded-xl overflow-hidden gap-2 pb-3">
      <div className="h-96 overflow-hidden flex">
        <img src="img/cartaz_coringa.jpg" className="object-cover w-full" alt="" />
      </div>
      <div className="flex flex-row items-center justify-center gap-2">
        <h2 className="text-lg text-white font-medium">Título</h2>
        <span className="min-w-16 font-semibold bg-white text-center bg-opacity-80 rounded-lg">
          5,0
        </span>
      </div>
      <div>
        <BtnWatchlist addOrDelete={addMovie} />
      </div>
    </div>
  );
}
export default ItemFilme;

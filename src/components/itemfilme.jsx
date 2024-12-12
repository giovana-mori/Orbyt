import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import BtnWatchlist from "./btnwachlist";
import BtnFavourite from "./btnfavourite";

function ItemFilme({
  imagem, titulo, nota, id,
}) {
  const [uId] = useState(id);
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/sobre/${uId}`, { state: { idFilme: id } });
  };
  const handleFavouriteClick = () => {
  };
  return (
    <div onClick={handleClick} className="cursor-pointer flex flex-col bg-fundocards max-w-xs border border-bordagray rounded-xl overflow-hidden gap-2 pb-3 relative">
      <div className="h-96 overflow-hidden flex">
        <div className="absolute top-2 right-2 p-2 z-10">
          <BtnFavourite title={titulo} id={id} onClick={handleFavouriteClick} />
        </div>
        <img
          src={`http://image.tmdb.org/t/p/w500/${imagem}`}
          className="object-cover w-full"
          alt=""
        />
      </div>
      <div className="flex flex-row items-center justify-center gap-2">
        <h2 className="text-lg text-white font-medium">{titulo}</h2>
        <span className="min-w-16 font-semibold bg-white text-center bg-opacity-80 rounded-lg">
          {nota}
        </span>
      </div>
      <div>
        <BtnWatchlist addOrDelete title={titulo} id={id} onClick={handleFavouriteClick} />
      </div>
    </div>
  );
}
export default ItemFilme;

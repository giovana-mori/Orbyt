import React, { useState } from "react";
import API from "../utils/API";

function BtnFavourite({
  active = false, onClick, id, title,
}) {
  const [isActive, setIsActive] = useState(active);
  const handleClick = () => {
    setIsActive(!isActive);
  };
  const watchFavorite = {
    NomeFilme: title,
    IdTmdb: id,
  };
  const favoriteMovie = () => {
    API.post('/Usuarios/favorite', watchFavorite).then((response) => { alert("filme favoritado"); }).catch((error) => { console.log(error.response.data); });
  };
  return (
    <button
      type="button"
      className="p-2 z-10 bg-white rounded-full"
      onClick={(e) => {
        e.stopPropagation();
        if (onClick) { handleClick(); favoriteMovie(); }
      }}
    >
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill={isActive ? "#5f53ab" : "none"}
        viewBox="0 0 24 24"
        strokeWidth={1.5}
        stroke={isActive ? "#5f53ab" : "black"}
        className="size-6"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12Z"
        />
      </svg>
      {}
    </button>
  );
}

export default BtnFavourite;

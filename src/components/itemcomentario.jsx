import React, { useState } from "react";
import { Link } from "react-router-dom";

function ItemComentario({ spoiler = false, logged = true }) {
  const [showSpoiler, setShowSpoiler] = useState(spoiler);

  function handleSpoiler() {
    setShowSpoiler(!showSpoiler);
  }
  return (
    <div className="bg-[#181818] relative border border-[#858585] rounded-2xl px-4 py-3 max-w-[550px] w-full flex flex-col gap-3 overflow-hidden">
      {!logged && (
        <div className="absolute inset-0 z-10 w-full h-full bg-black bg-opacity-50 backdrop-blur-sm flex justify-center items-center">
          <Link
            to="/login"
            className="text-black font-bold text-lg bg-white rounded-lg px-2 flex flex-col items-center justify-center"
          >
            Faça login para ver
          </Link>
        </div>
      )}
      {showSpoiler && (
        <div className="absolute inset-0 z-10 w-full h-full bg-black bg-opacity-50 backdrop-blur-sm flex justify-center items-center">
          <span
            onClick={handleSpoiler}
            onKeyDown={(e) => {
              if (e.key === "Enter" || e.key === " ") {
                handleSpoiler();
              }
            }}
            tabIndex={0}
            role="button"
            className="text-black font-bold text-lg bg-white rounded-lg px-2 flex flex-row items-center justify-center gap-1"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              strokeWidth={1.5}
              stroke="currentColor"
              className="size-6"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M2.036 12.322a1.012 1.012 0 0 1 0-.639C3.423 7.51 7.36 4.5 12 4.5c4.638 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.638 0-8.573-3.007-9.963-7.178Z"
              />
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z"
              />
            </svg>
            Revelar Comentário
          </span>
        </div>
      )}
      <div className="flex flex-row gap-4">
        <div className="w-16 h-16 bg-[#858585] rounded-full overflow-hidden">
          <img src="/img/avatar.jpg" alt="" />
        </div>
        <div className="flex flex-col items-center">
          <h1 className="text-white font-semibold text-lg">Nome do usuário</h1>
          <div className="flex flex-row w-full">
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
          </div>
        </div>
      </div>
      <div className="flex flex-col gap-4">
        <p className="text-white font-normal text-sm line-clamp-4 text-justify">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas
          facilisis elementum porttitor. Maecenas et mi ac elit vestibulum
          posuere eu sit amet eros. Suspendisse aliquam varius congue.
        </p>
      </div>
      <div className="flex flex-row gap-4">
        <div className="flex flex-row gap-2">
          <img src="/img/like.svg" alt="" />
          <span className="text-white font-normal text-lg">10</span>
        </div>
        <div className="flex flex-row gap-2">
          <img src="/img/deslike.svg" alt="" />
          <span className="text-white font-normal text-lg">10</span>
        </div>
      </div>
    </div>
  );
}
export default ItemComentario;

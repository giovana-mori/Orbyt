import React from "react";
import { Link } from "react-router-dom";
import BtnFavourite from "./btnfavourite";

export default function PrevFilme({
  titulo,
  descricao,
  genero,
  nota,
  sobre = true,
}) {
  return (
    <div className="flex flex-col gap-2 max-w-96">
      <div>
        <h2 className="text-4xl font-semibold text-white">{titulo}</h2>
      </div>
      <div className="flex flex-row gap-2">
        {genero.map((gen) => (
          <div
            key={gen}
            className="min-w-28 p-1 text-center text-white font-normal text-sm bg-black rounded-md bg-opacity-50 shadow"
          >
            {gen}
          </div>
        ))}
      </div>
      <div className="flex flex-row gap-2 items-center">
        <div>
          <BtnFavourite />
        </div>
        <div>
          <div className="flex flex-row w-full">
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
          </div>
        </div>
        <div>
          <span className="min-w-16 font-semibold bg-white text-center bg-opacity-80 rounded-lg px-3">
            {nota}
          </span>
        </div>
      </div>
      <div className="text-white text-justify text-base ">{descricao}</div>
      <div className="flex flex-row gap-2">
        {sobre && (
          <Link
            to="/sobre/872585"
            className="bg-white text-black font-semibold text-base px-4 py-2 rounded-md"
            state={{ idFilme: 872585 }}
          >
            Sobre
          </Link>
        )}
        <button
          type="button"
          className="bg-primary text-white font-semibold text-base px-4 py-2 rounded-md flex items-center gap-2"
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
              d="M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"
            />
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              d="M15.91 11.672a.375.375 0 0 1 0 .656l-5.603 3.113a.375.375 0 0 1-.557-.328V8.887c0-.286.307-.466.557-.327l5.603 3.112Z"
            />
          </svg>
          Assistir trailer
        </button>
      </div>
    </div>
  );
}

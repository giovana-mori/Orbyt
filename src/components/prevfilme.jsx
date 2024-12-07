import React from "react";
import { Link } from "react-router-dom";
import BtnFavourite from "./btnfavourite";

export default function PrevFilme(
  {
    titulo = "Titulo do filme",
    descricao = "Descrição do filme",
    genero = [],
    nota = 5,
  },
) {
  return (
    <div className="flex flex-col gap-2 max-w-96">
      <div>
        <h2 className="text-4xl font-semibold text-white">{titulo}</h2>
      </div>
      <div className="flex flex-row gap-2">
        {
                    genero.map((gen) => (
                      <div key={gen} className="min-w-28 p-1 text-center text-white font-normal text-sm bg-black rounded-md bg-opacity-50 shadow">
                        {gen}
                      </div>
                    ))
                }
      </div>
      <div className="flex flex-row gap-2 items-center">
        <div>
          <BtnFavourite />
        </div>
        <div>
          <div className="flex flex-row w-full">
            <img className="w-8" src="img/star.svg" alt="" />
            <img className="w-8" src="img/star.svg" alt="" />
            <img className="w-8" src="img/star.svg" alt="" />
            <img className="w-8" src="img/star.svg" alt="" />
            <img className="w-8" src="img/star.svg" alt="" />
          </div>

        </div>
        <div>
          <span className="min-w-16 font-semibold bg-white text-center bg-opacity-80 rounded-lg px-3">
            {nota}
          </span>
        </div>
      </div>
      <div className="text-white text-justify text-base ">
        {descricao}
      </div>
      <div className="flex flex-row gap-2">
        <Link to="/sobre" className="bg-white text-black font-semibold text-base px-4 py-2 rounded-md">
          Sobre
        </Link>
        <button type="submit" className="bg-black text-white font-semibold text-base px-4 py-2 rounded-md">
          Trailer
        </button>
      </div>
    </div>
  );
}

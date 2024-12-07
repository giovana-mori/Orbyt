/* eslint-disable */

import React from "react";
import { Link } from "react-router-dom";

function Navbar() {
  const handleSearch = (event) => {
    event.preventDefault();
    // Lógica de busca aqui
  };

  return (
    <nav className="bg-black shadow-md">
      <div className="container mx-auto flex items-center justify-between py-2">
        <Link to="/">
          <div className="flex items-center gap-1">
            <img src="img/logo_nav.png" alt="Logo" className="h-20" />
            <img src="img/text_svg_nav.svg" alt="Logo" className="w-32" />
          </div>
        </Link>
        <div className="flex items-center mx-4 gap-2 flex-1 max-w-lg justify-center">
          <div className="relative w-full max-w-lg">
            <input
              type="text"
              placeholder="Busca..."
              onChange={handleSearch}
              className="w-full text-black text-base rounded-md py-2 pr-10 pl-2 bg-gray-200 border-primary border-2 focus:outline-none focus:ring-2 focus:ring-primary"
            />
            <svg
              className="absolute top-2 right-3 w-5 h-7 text-primary"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 20 20"
            >
              <path
                stroke="currentColor"
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
              />
            </svg>
          </div>
        </div>
        <div className="flex space-x-6">
          <Link
            to="login"
            className="text-white transition-all font-bebas bg-primary hover:bg-opacity-35 font-medium rounded-lg  tracking-wider text-xl px-4 py-1 text-center"
          >
            ENTRAR
          </Link>
        </div>
      </div>
      <div className="bg-[#5e52aa33]">
        <div className="container mx-auto flex items-center justify-evenly gap-[2%] py-2">
          {[
            "LANÇAMENTOS",
            "AVENTURA",
            "AÇÃO",
            "DRAMA",
            "COMÉDIA",
            "FICÇÃO CIENTÍFICA",
            "MUSICAL",
            "ROMANCE",
            "TERROR",
            "ANIMAÇÃO",
            "DOCUMENTÁRIO",
          ].map((item, index) => (
            <Link
              key={index}
              to="/filmes"
              className="text-white font-normal hover:underline font-bebas leading-[normal] text-xl text-left tracking-wide"
            >
              {item}
            </Link>
          ))}
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

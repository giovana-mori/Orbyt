import React from "react";
import { Link } from "react-router-dom";

function Navbar() {
  return (
    <nav className="bg-black py-4 shadow-md">
      <div className="container mx-auto flex items-center justify-between">
        <Link to="/perfil">
          <img
            src="img/LOGOPLANETA.SVG"
            alt="Logo"
            className="h-20"
          />
        </Link>
        <div className=" mx-4 flex gap-2">
          <div className="relative w-full max-w-lg">
            <input
              type="text"
              placeholder="Busca..."
              className="w-full p-2 text-black rounded-full pl-10 bg-gray-200 focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
            <svg
              className="absolute top-2.5 right-3 w-5 h-5 text-gray-500"
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
          <Link
            to="/filmes"
            className="text-white font-normal hover:underline font-bebas text-5xl text-left"
          >
            FILMES
          </Link>
        </div>
        <div className="flex space-x-6">
          <Link
            to="/login"
            className="text-white font-normal hover:underline font-bebas text-5xl text-right"
          >
            LOGIN
          </Link>
          <Link
            to="/registro"
            className="text-white font-normal hover:underline font-bebas text-5xl text-right"
          >
            CRIAR CONTA
          </Link>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

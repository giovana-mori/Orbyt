/* eslint-disable */
import React from "react";
import { Link } from "react-router-dom";

function MenuPerfil() {
  return (
    <div className="flex flex-col my-20">
      <ul className="flex flex-col gap-4">
        <li className="w-full">
          <Link
            className="text-left text-white font-bold text-xl border-b border-white w-full block"
            to="/perfil"
          >
            Visão Geral
          </Link>
        </li>
        <li>
          <Link
            className="text-left text-white font-bold text-xl border-white w-full block"
            to="/configuracoes"
          >
            Configurações
          </Link>
        </li>
      </ul>
    </div>
  );
}

export default MenuPerfil;

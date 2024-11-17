import React from "react";

function MenuPerfil() {
  return (
    <div className="flex flex-col my-20">
      <ul className="flex flex-col gap-4">
        <li className="w-full">
          <a className="text-left text-white font-bold text-3xl border-b border-white w-full block" href="/perfil">Visão Geral</a>
        </li>
        <li>
          <a className="text-left text-white font-bold text-3xl border-white w-full block" href="/perfil">Configurações</a>
        </li>
      </ul>
    </div>
  );
}

export default MenuPerfil;

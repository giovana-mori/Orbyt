import React from "react";
import Avatar from "../components/avatar";
import ContainerCard from "../components/containercard";
import MenuPerfil from "../components/menuperfil";
import ItemComentario from "../components/itemcomentario";
import ItemFilme from "../components/itemfilme";

function Perfil() {
  return (
    <div>
      <ContainerCard>
        <div className="flex flex-row gap-10">
          <div className="border-r-2">
            <div className="mr-10">
              <Avatar />
            </div>
            <MenuPerfil />
          </div>
          <div>
            <ItemComentario />
            <div>
              <ItemFilme />
            </div>
          </div>
        </div>
      </ContainerCard>
    </div>
  );
}
export default Perfil;

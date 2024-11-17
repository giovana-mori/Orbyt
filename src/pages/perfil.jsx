import React from "react";
import Avatar from "../components/avatar";
import ContainerCard from "../components/containercard";
import MenuPerfil from "../components/menuperfil";
import ItemComentario from "../components/itemcomentario";

function Perfil() {
  return (
    <div>
      <ContainerCard>
        <div className="flex flex-row">
          <div>
            <Avatar />
            <MenuPerfil />
          </div>
          <div>
            <ItemComentario />
          </div>
        </div>
      </ContainerCard>
    </div>
  );
}
export default Perfil;

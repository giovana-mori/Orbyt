import React from "react";
import Avatar from "../components/avatar";
import ContainerCard from "../components/containercard";
import MenuPerfil from "../components/menuperfil";

function Perfil() {
  return (
    <div>
      <ContainerCard>
        <Avatar />
        <MenuPerfil />
      </ContainerCard>
    </div>
  );
}
export default Perfil;

/* eslint-disable */

import React from "react";
import Avatar from "../components/avatar";
import ContainerCard from "../components/containercard";
import MenuPerfil from "../components/menuperfil";
import NavigationTitle from "../components/navigationtitle";
import BannerSobre from "../components/bannersobre";
import ItemComentario from "../components/itemcomentario";

function Comentarios() {
  return (
    <div className="flex flex-col gap-3">
      <BannerSobre />
      <ContainerCard>
        <NavigationTitle title="Comentários" />
        <div className="flex flex-col justify-center items-center gap-4">
          {[1, 2, 3, 4, 5, 6, 7].map((item, index) => (
            <ItemComentario key={index} spoiler={index % 2 === 0} />
          ))}
        </div>
      </ContainerCard>
    </div>
  );
}
export default Comentarios;

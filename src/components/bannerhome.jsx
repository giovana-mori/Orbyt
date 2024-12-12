import React from "react";
import PrevFilme from "./prevfilme";

export default function BannerHome({
  imgpath = "img/openheimmer.jpg",
  title = "Openheimmer",
  description = "A história do físico americano J. Robert Oppenheimer, seu papel no Projeto Manhattan e no desenvolvimento da bomba atômica durante a Segunda Guerra Mundial, e o quanto isso mudaria a história do mundo para sempre.",
  nota = 5,
  genero = ["Suspense", "Terror", "Comédia"],
}) {
  return (
    <div
      className='bg-cover bg-center relative bg-no-repeat py-20 before:absolute before:bottom-0 before:left-0 before:z-10 before:block before:h-full before:w-3/5 before:bg-gradient-to-r before:from-black before:to-ing-neutral-700/0 before:opacity-85 before:content-[""]'
      style={{ backgroundImage: `url(${imgpath})` }}
    >
      <div className="container mx-auto px-4">
        <div className="z-20 relative">
          <PrevFilme
            titulo={title}
            genero={genero}
            descricao={description}
            nota={nota}
          />
        </div>
        <div />
      </div>
    </div>
  );
}

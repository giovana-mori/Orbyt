import React from "react";
import PrevFilme from "./prevfilme";

export default function BannerSobre({
  imgpath,
  posterPath,
  title,
  description,
  nota,
  genero,
}) {
  return (
    <div
      className='bg-cover bg-center relative bg-no-repeat py-20 before:absolute before:bottom-0 before:left-0 before:z-10 before:block before:h-full before:w-3/5 before:bg-gradient-to-r before:from-black before:to-ing-neutral-700/0 before:opacity-85 before:content-[""]'
      style={{ backgroundImage: `url(${`https://image.tmdb.org/t/p/w500${imgpath}`})` }}
    >
      <div className="container mx-auto px-4">
        <div className="z-20 relative flex gap-4">
          <div className="items-center flex flex-col gap-2">
            <img src={`http://image.tmdb.org/t/p/w300/${posterPath}`} alt="" />
            <span className="font-bebas text-2xl text-white">
              ONDE ASSISTIR
            </span>
            <div className="flex gap-2">
              {["netflix.png", "youtube.png", "primevideo.png"].map((item, index) => (
                <div key={index}>
                  <img src={`/img/icons_streams/${item}`} alt="" />
                </div>
              ))}
            </div>
          </div>
          <PrevFilme
            titulo={title}
            genero={genero}
            descricao={description}
            nota={nota}
            sobre={false}
          />
        </div>
        <div />
      </div>
    </div>
  );
}

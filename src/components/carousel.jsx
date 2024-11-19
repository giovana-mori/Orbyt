/* eslint-disable */
import React from "react";
import { Swiper } from "swiper/react";
import "swiper/swiper-bundle.css";
import { Navigation } from "swiper/modules";
import { Link } from "react-router-dom";

const CarouselSlick = ({ title, link = "#", slidesPerView = 2, children }) => (
  <div className="w-full">
    <div className="flex items-center justify-between py-4 pb-2">
      <h2 className="font-bebas text-4xl text-white">{title}</h2>
      <div>
        {/* Link to comentarios */}
        <Link
          to={link}
          className="text-white text-2xl font-normal font-bebas hover:underline"
        >
          VER TUDO
        </Link>
      </div>
    </div>
    {/* Certifique-se de que o contêiner do Swiper tenha 100% da largura disponível */}
    <Swiper
      spaceBetween={10} // Espaço entre os slides
      slidesPerView={slidesPerView} // Exibe 2 slides inteiros ao mesmo tempo
      centeredSlides={true} // Garante que o slide ativo fique centralizado
      loop={true} // Habilita o loop
      navigation={true} // Habilita os botões de navegação
      modules={[Navigation]} // Certifique-se de importar e usar o módulo de navegação
      className="w-full" // A classe w-full garante que o Swiper ocupe toda a largura disponível
    >
      {children}
    </Swiper>
  </div>
);

export default CarouselSlick;

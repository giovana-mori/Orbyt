/* eslint-disable */
import React from "react";
import { Swiper } from "swiper/react";
import "swiper/swiper-bundle.css";
import { Navigation } from "swiper/modules";

const CarouselSlick = ({ children }) => (
  <div className="w-full">
    {" "}
    {/* Certifique-se de que o contêiner do Swiper tenha 100% da largura disponível */}
    <Swiper
      spaceBetween={10} // Espaço entre os slides
      slidesPerView={2} // Exibe 2 slides inteiros ao mesmo tempo
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

/* eslint-disable */

import React from "react";
import { SwiperSlide } from "swiper/react";
import Avatar from "../components/avatar";
import ContainerCard from "../components/containercard";
import MenuPerfil from "../components/menuperfil";
import CarouselSlick from "../components/carousel";
import ItemComentario from "../components/itemcomentario";
import ItemFilme from "../components/itemfilme";
import NavigationTitle from "../components/navigationtitle";

function Perfil() {
  return (
    <div>
      <ContainerCard>
        <NavigationTitle title="perfil do usuário" />
        <div className="grid grid-cols-1 md:grid-cols-4 gap-10">
          <div className="border-r-2 md:border-r-2 md:col-span-1">
            <div className="flex items-center px-4">
              <Avatar />
            </div>
            <MenuPerfil />
          </div>
          <div className="md:col-span-3">
            <CarouselSlick title="MINHAS AVALIAÇÕES">
              <SwiperSlide className="w-full">
                <ItemComentario />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemComentario />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemComentario />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemComentario />
              </SwiperSlide>
            </CarouselSlick>
            <hr className="my-4 border-white border-2" />
            <CarouselSlick title="FILMES FAVORITOS" slidesPerView={3}>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
            </CarouselSlick>
            <hr className="my-4 border-white border-2" />
            <CarouselSlick title="QUERO ASSISTIR" slidesPerView={3}>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
              <SwiperSlide className="w-full">
                <ItemFilme />
              </SwiperSlide>
            </CarouselSlick>
          </div>
        </div>
      </ContainerCard>
    </div>
  );
}
export default Perfil;

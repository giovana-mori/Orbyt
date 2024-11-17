/* eslint-disable */
import React from "react";
import Avatar from "../components/avatar";
import ContainerCard from "../components/containercard";
import MenuPerfil from "../components/menuperfil";
import CarouselSlick from "../components/carousel";
import { SwiperSlide } from "swiper/react";
import ItemComentario from "../components/itemcomentario";

function Perfil() {
  return (
    <div>
      <ContainerCard>
        <div className="grid grid-cols-1 md:grid-cols-4 gap-10">
          <div className="border-r-2 md:border-r-2 md:col-span-1">
            <div className="flex items-center px-4">
              <Avatar />
            </div>
            <MenuPerfil />
          </div>
          <div className="md:col-span-3">
            <CarouselSlick>
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
          </div>
        </div>
      </ContainerCard>
    </div>
  );
}
export default Perfil;

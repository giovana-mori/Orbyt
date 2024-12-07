/* eslint-disable */

import React from "react";
import { SwiperSlide } from "swiper/react";
import BannerHome from "../components/bannerhome";
import CarouselSlick from "../components/carousel";
import ItemFilme from "../components/itemfilme";
import ContainerCard from "../components/containercard";

export default function Home() {
  return (
    <div className="home">
      <div className="flex flex-col gap-5">
        <BannerHome imgpath="img/openheimmer.jpg" />
        <ContainerCard>
          <div className="flex justify-between items-center p-5">
            <h2 className="text-white text-8xl font-bebas w-3/12 pr-32 bg-gradient-to-r from-white to-gray-500 inline-block text-transparent bg-clip-text">
              TOP MAIS VOTADOS
            </h2>
            <div className="w-9/12">
              <CarouselSlick slidesPerView={3}>
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

        <ContainerCard>
          <div className="flex justify-between items-center p-5">
            <h2 className="text-white text-8xl font-bebas w-3/12 pr-32 bg-gradient-to-r from-white to-gray-500 inline-block text-transparent bg-clip-text">
              FILMES DE TERROR
            </h2>
            <div className="w-9/12">
              <CarouselSlick slidesPerView={3}>
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
    </div>
  );
}

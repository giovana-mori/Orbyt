/* eslint-disable */

import React from "react";
import { Swiper } from "swiper/react"; /* o que é esse swiper? */
import "swiper/swiper-bundle.css";
import { Navigation } from "swiper/modules";
import { Link } from "react-router-dom";

function CarouselSlick({ title, link, slidesPerView = 2, children }) {
  return (
    <div className="w-full">
      <div className="flex items-center justify-between py-4">
        <h2 className="font-bebas text-4xl text-white">{title}</h2>
        {link && (
          <Link
            to={link}
            className="text-white text-2xl font-normal font-bebas hover:underline"
          >
            VER TUDO
          </Link>
        )}
        <div></div>
      </div>
      {/* Usem menos chatgpt please */}
      <Swiper
        spaceBetween={10}
        slidesPerView={slidesPerView}
        centeredSlides
        loop
        navigation
        modules={[Navigation]}
        className="w-full"
      >
        {children}
      </Swiper>
    </div>
  );
}

export default CarouselSlick;

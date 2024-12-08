/* eslint-disable */
// import { useParams } from "react-router-dom";
import React from "react";
import { SwiperSlide } from "swiper/react";
import ContainerCard from "../components/containercard";
import BannerSobre from "../components/bannersobre";
import CarouselSlick from "../components/carousel";
import ItemComentario from "../components/itemcomentario";
import CommentForm from "../components/commentform";

function Sobre() {
  //   const { slug } = useParams();
  const movie = {
    description:
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim.",
    genre: "Ação, Aventura, Suspense",
    year: "2022",
    duracao: "2h 7min",
    diretor: "Matt Reeves",
    cast: "Robert Pattinson, Zoë Kravitz, Paul Dano, Jeffrey Wright",
    review:
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim. Nulla quam velit, dapibus at dui id, dapibus imperdiet enim.",
  };
  return (
    <div>
      <div className="flex flex-col gap-3">
        <BannerSobre />
        <ContainerCard>
          <div className="flex flex-col gap-4">
            <CarouselSlick title="COMENTÁRIOS" slidesPerView={3}>
              {[1,2,3,4,5,6,7].map((item) => (
                <SwiperSlide className="w-full" key={item}>
                  <ItemComentario spoiler={false} logged={false} />
                </SwiperSlide>
              ))}
            </CarouselSlick>
            <hr className="my-4 border-white border-2" />
            <CarouselSlick title="COMENTÁRIOS COM SPOILER" slidesPerView={3}>
              {[1,2,3,4,5,6,7].map((item) => (
                <SwiperSlide className="w-full" key={item}>
                  <ItemComentario spoiler={true} logged={false} />
                </SwiperSlide>
              ))}
            </CarouselSlick>
            <hr className="my-4 border-white border-2" />
            <h2 className="font-bebas text-4xl text-white">
              O QUE VOCE ACHOU?
            </h2>
            <CommentForm enableComment={false} />
            <hr className="my-4 border-white border-2" />
            <h2 className="font-bebas text-4xl text-white">
              INFORMACÕES DO FILME
            </h2>
            <div className="bg-[#181818] rounded-md flex flex-col gap-3 my-2">
              <ul className="flex flex-col justify-center">
                {Object.keys(movie).map((key) => {
                  return (
                    <li className="text-white font-bold text-lg flex gap-4 even:border-t-2 even:border-b-2 py-3 border-white items-center p-4 min-h-20">
                      <span className="w-full max-w-36 text-white font-bold text-xl">
                        {key.charAt(0).toUpperCase() + key.slice(1)}:
                      </span>
                      <span className="text-white text-lg font-normal">
                        {movie[key]}
                      </span>
                    </li>
                  );
                })}
              </ul>
            </div>
          </div>
        </ContainerCard>
      </div>
    </div>
  );
}

export default Sobre;

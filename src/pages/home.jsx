import React, { useCallback, useEffect, useState } from "react";
import { SwiperSlide } from "swiper/react";
import BannerHome from "../components/bannerhome";
import CarouselSlick from "../components/carousel";
import ItemFilme from "../components/itemfilme";
import ContainerCard from "../components/containercard";
import API from "../utils/API";

export default function Home() {
  const [movie, setMovie] = useState([]);
  const [movieTerror, setMovieTerror] = useState([]);
  const FetchMovie = useCallback(() => {
    API.get(`/Movies/category?page=1&category=popular`).then((response) => {
      if (response.data) {
        setMovie(
          response.data.results.map((movies) => ({
            ...movies,
            key: `movie-${movies.id}`,
          })),
        );
      }
    });
  }, []);
  const FetchMovieTerror = useCallback(() => {
    API.get(`/Movies/pesquisar/atividade-paranormal`).then((response) => {
      if (response.data) {
        setMovieTerror(
          response.data.results.map((movies) => ({
            ...movies,
            key: `movie-${movies.id}`,
          })),
        );
      }
    });
  }, []);
  useEffect(() => { FetchMovie(); FetchMovieTerror(); }, [FetchMovie, FetchMovieTerror]);
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

                {movie.map((movies) => (
                  <SwiperSlide key={movies.id} className="w-full">
                    <ItemFilme
                      key={movies.key}
                      id={movies.id}
                      imagem={movies.poster_path}
                      titulo={movies.title}
                    />
                  </SwiperSlide>
                ))}
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
                {movieTerror.map((movies) => (
                  <SwiperSlide key={movies.id} className="w-full">
                    <ItemFilme key={movies.key} imagem={movies.poster_path} titulo={movies.title} />
                  </SwiperSlide>
                ))}
              </CarouselSlick>
            </div>
          </div>
        </ContainerCard>
      </div>
    </div>
  );
}

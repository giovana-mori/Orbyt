import React, { useEffect, useState } from "react";
import { SwiperSlide } from "swiper/react";
import { useLocation } from "react-router-dom";
import ContainerCard from "../components/containercard";
import BannerSobre from "../components/bannersobre";
import CarouselSlick from "../components/carousel";
import ItemComentario from "../components/itemcomentario";
import CommentForm from "../components/commentform";
import API from "../utils/API";

function Sobre() {
  const [movieDetails, setMovieDetails] = useState([]);
  const location = useLocation();
  const filmeDetailId = location.state;

  const fetechMoviesId = () => {
    if (filmeDetailId.idFilme == null) {
      API.get(`Movies/details/${filmeDetailId}`).then((response) => {
        if (response.data) {
          setMovieDetails({ ...response.data, key: `movie-${response.data.id}` });
        }
      });
    } else {
      API.get(`Movies/details/${filmeDetailId.idFilme}`).then((response) => {
        if (response.data) {
          setMovieDetails({ ...response.data, key: `movie-${response.data.id}` });
        }
      });
    }
  };
  useEffect(() => {
    fetechMoviesId();
  }, []);

  const generos = Array.isArray(movieDetails.genres) ? movieDetails.genres.map((g) => g.name) : [];
  const labels = {
    release_date: "Data de Lançamento",
    revenue: "Receita",
    runtime: "Duração",
    status: "Status",
    tagline: "Slogan",
    origin_country: "Pais-Original",
    original_language: "Lingua-Original",
  };
  return (
    <div>
      <div className="flex flex-col gap-3">
        {movieDetails.title && (
        <BannerSobre
          title={movieDetails.title}
          description={movieDetails.overview}
          imgpath={movieDetails.backdrop_path}
          posterPath={movieDetails.poster_path}
          genero={generos}
        />
        )}
        <ContainerCard>
          <div className="flex flex-col gap-4">
            <CarouselSlick title="COMENTÁRIOS" slidesPerView={3}>
              {[1, 2, 3, 4, 5, 6, 7].map((item) => (
                <SwiperSlide className="w-full" key={item}>
                  <ItemComentario spoiler={false} logged={false} />
                </SwiperSlide>
              ))}
            </CarouselSlick>
            <hr className="my-4 border-white border-2" />
            <CarouselSlick title="COMENTÁRIOS COM SPOILER" slidesPerView={3}>
              {[1, 2, 3, 4, 5, 6, 7].map((item) => (
                <SwiperSlide className="w-full" key={item}>
                  <ItemComentario spoiler logged={false} />
                </SwiperSlide>
              ))}
            </CarouselSlick>
            <hr className="my-4 border-white border-2" />
            <h2 className="font-bebas text-4xl text-white">O QUE VOCE ACHOU?</h2>
            <CommentForm enableComment={false} />
            <hr className="my-4 border-white border-2" />
            <h2 className="font-bebas text-4xl text-white">INFORMAÇÕES DO FILME</h2>
            <div className="bg-[#181818] rounded-md flex flex-col gap-3 my-2">

              <ul>
                {Object.keys(movieDetails)
                  .filter((key) => Object.keys(labels).includes(key))
                  .map((key) => {
                    if (movieDetails[key] !== null) {
                      return (
                        <li
                          key={key}
                          className="text-white font-bold text-lg flex gap-4 even:border-t-2 even:border-b-2 py-3 border-white items-center p-4 min-h-20"
                        >
                          <span className="w-full max-w-36 text-white font-bold text-xl">
                            {labels[key]}
                            :
                          </span>
                          <span className="text-white text-lg font-normal">
                            {movieDetails[key]}
                          </span>
                        </li>
                      );
                    }
                    return null;
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

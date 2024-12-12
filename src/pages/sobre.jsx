import React, { useEffect, useState } from "react";
import { SwiperSlide } from "swiper/react";
import { Link, useLocation } from "react-router-dom";
import { comment } from "postcss";
import ContainerCard from "../components/containercard";
import BannerSobre from "../components/bannersobre";
import CarouselSlick from "../components/carousel";
import ItemComentario from "../components/itemcomentario";
import CommentForm from "../components/commentform";
import API from "../utils/API";
import { useAuth } from "../utils/authContext";

function Sobre() {
  const [movieDetails, setMovieDetails] = useState([]);
  const location = useLocation();
  const filmeDetailId = location.state;
  const createPost = {
    idFilme: filmeDetailId.idFilme,
    comment: "",
    nota: 0,
    spoiler: false,
  };
  const { user } = useAuth();
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
  const [formData, setFormData] = useState({
    spoiler: false,
    comentario: "",
  });
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const createComment = () => {
    API.post('Avaliacao/criar-avaliacao', {
      ...createPost,
      idFilme: filmeDetailId.idFilme,
      comment: formData.comentario,
      nota: 0,
      spoiler: formData.spoiler,
    }).then(console.log("X"));
  };
  const handleSubmit = () => {
    createComment();
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
            {user ? (
              <div className="bg-[#181818] rounded-md flex flex-col items-center justify-center gap-3 my-2 p-3 min-h-28">
                <Link
                  to="/login"
                  className="text-white font-bold text-lgbg-white rounded-lg px-2 flex flex-col items-center justify-center"
                >
                  Faça login para comentar
                </Link>
              </div>
            ) : (
              <form>
                <div className="bg-[#181818] rounded-md flex flex-col gap-3 my-2 p-3" onChange={handleChange}>
                  <div className="flex flex-row w-full items-center justify-center">
                    <img className="w-8" src="/img/star.svg" alt="" />
                    <img className="w-8" src="/img/star.svg" alt="" />
                    <img className="w-8" src="/img/star.svg" alt="" />
                    <img className="w-8" src="/img/star.svg" alt="" />
                    <img className="w-8" src="/img/star.svg" alt="" />
                  </div>
                  <textarea
                    value={formData.comentario}
                    name="comentario"
                    id="comentario"
                    className="w-full resize-none rounded-md bg-zinc-500 text-white min-h-40 text-xl p-3 font-bold"
                    placeholder="Escreva um comentário sobre"
                  />
                  <label htmlFor="?" className="text-white flex items-center gap-2">
                    <input
                      type="checkbox"
                      value={formData.spoiler}
                      name="spoiler"
                      id="spoiler"
                      className="size-5 bg-transparent"
                    />
                    Marcar comentário como spoiler
                  </label>
                  <button onClick={() => handleSubmit()} type="submit" className="text-white">COMENTAR</button>

                </div>
              </form>
            )}
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

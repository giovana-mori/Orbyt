import React, { useEffect, useState } from 'react';
import { Link, useLocation } from "react-router-dom";
import NavigationTitle from '../components/navigationtitle';
import ContainerCard from '../components/containercard';
import MovieCatalog from '../components/categorycatalog';
import CardFilme from '../components/cardfilme';
import API from '../utils/API';

function Pesquisa() {
  const [movieSearch, setMovieSearch] = useState([]);
  const location = useLocation();
  const search = location.search.slice(6);
  console.log(search);

  const FetchMovieSeach = () => {
    API.get(`/Movies/pesquisar?nome=${search}`).then((response) => {
      if (response.data) {
        setMovieSearch(
          response.data.results.map((movies) => ({
            ...movies,
            key: `movie-${movies.id}`,
          })),
        );
      }
    });
  };
  console.log(movieSearch);

  useEffect(() => { FetchMovieSeach(); }, []);
  return (
    <div>
      <ContainerCard>
        <NavigationTitle title={`Resultados para: ${search}`} />
        <div className="flex flex-col gap-4">
          <Link
            to="/filmes"
            className="grid text-white font-normal hover:underline font-bebas leading-[normal] text-2xl text-right justify-end"
          >
            Pesquisa avançada
            {/* q q é isso aq veio? */}
          </Link>
          <MovieCatalog>
            {movieSearch.length > 0 ? (movieSearch.map((item) => (
              <CardFilme
                key={item.id}
                image={item.poster_path}
                title={item.title}
                score={item.vote_average}
                overview={item.overview.length > 80 ? `${item.overview.slice(0, 80)}...` : item.overview}
              />
            ))) : <p>Carregando...</p>}
          </MovieCatalog>
        </div>

      </ContainerCard>
    </div>
  );
}

export default Pesquisa;

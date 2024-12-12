import React, { useEffect, useState } from 'react';
import { useLocation } from "react-router-dom";
import NavigationTitle from '../components/navigationtitle';
import ContainerCard from '../components/containercard';
import MovieCatalog from '../components/categorycatalog';
import CardFilme from '../components/cardfilme';
import API from '../utils/API';

function Pesquisa() {
  const [movieSearch, setMovieSearch] = useState([]);
  const location = useLocation();
  const search = location.search.slice(6);

  const FetchMovieSeach = () => {
    API.get(`/Movies/pesquisar/${search}`).then((response) => {
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

  useEffect(() => { FetchMovieSeach(); }, []);
  return (
    <div>
      <ContainerCard>
        <NavigationTitle title={`Resultados para: ${search}`} />
        <div className="flex flex-col gap-4">
          <MovieCatalog>
            {movieSearch.length > 0 ? (movieSearch.map((item) => (
              <CardFilme
                key={item.id}
                image={item.poster_path}
                title={item.title}
                score={item.vote_average}
                overview={item.overview.length > 80 ? `${item.overview.slice(0, 80)}...` : item.overview}
                onClick
              />
            ))) : <p>Carregando...</p>}
          </MovieCatalog>
        </div>

      </ContainerCard>
    </div>
  );
}

export default Pesquisa;

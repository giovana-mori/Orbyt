import React, { useCallback, useEffect, useState } from 'react';
import NavigationTitle from '../components/navigationtitle';
import ItemFilme from '../components/itemfilme';
import ContainerCard from '../components/containercard';
import Filter from '../components/filters/filter';
import Category from '../components/filters/category';
import Streaming from '../components/filters/streaming';
import Year from '../components/filters/year';
import OrderBy from '../components/filters/orderby';
import Review from '../components/filters/review';
import MovieCatalog from '../components/categorycatalog';
import API from '../utils/API';

function Filmes() {
  const [movie, setMovie] = useState([]);
  const [loading] = useState(false);
  const FetchMovie = () => {
    API.get('/Movies/populares').then((response) => {
      if (response.data) {
        setMovie(
          response.data.results.map((movies) => ({
            ...movies,
            key: `movie-${movies.id}`,
          })),
        );
        console.log(response.data);
      }
    });
  };

  const handleScroll = useCallback(() => {
    if (
      window.innerHeight + window.scrollY >= document.body.scrollHeight - 20
      && !loading
    ) {
      FetchMovie();
    }
  }, []);

  useEffect(() => {
    if (movie.length === 0) {
      FetchMovie();
    }
    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  }, [loading]);

  return (
    <div>
      <ContainerCard>
        <NavigationTitle title="filmes" />
        <Filter>
          <OrderBy />
          <Category />
          <Review />
          <Streaming />
          <Year />
        </Filter>
        <MovieCatalog>
          {movie.length > 0 ? (
            movie.map((item) => (
              <ItemFilme
                key={item.id}
                titulo={item.title}
                imagem={item.poster_path}
                nota={item.vote_average}
              />
            ))
          ) : (
            <p>Carregando filmes...</p>
          )}
        </MovieCatalog>

      </ContainerCard>
    </div>
  );
}

export default Filmes;

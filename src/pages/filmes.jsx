/* eslint-disable */
import React from 'react';
import NavigationTitle from '../components/navigationtitle';
import ItemFilme from '../components/itemfilme';
import ContainerCard from '../components/containercard';
import Filter from '../components/filters/filter';
import Category from '../components/filters/category';
import Streaming from '../components/filters/streaming';
import Year from '../components/filters/year';
import OrderBy from '../components/filters/orderby';
import Review from '../components/filters/review';
import MovieCatalog from '../components/moviecatalog';

function Filmes() {
    return (
        <div>
            <ContainerCard>
                <NavigationTitle title={"filmes"} />
                <Filter>
                    <OrderBy/>
                    <Category/>
                    <Review/>
                    <Streaming/>
                    <Year/>
                </Filter>
                <MovieCatalog>
                    <ItemFilme /> {/*toda essa parte vai ser mudada por data.map()*/}
                    <ItemFilme />   {/*ou pelo menos eu acho kkkkkkkk*/}
                    <ItemFilme />
                    <ItemFilme />
                    <ItemFilme />
                    <ItemFilme />
                    <ItemFilme />
                    <ItemFilme />
                </MovieCatalog>
                
            </ContainerCard>
        </div>
    );
}

export default Filmes;
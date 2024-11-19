/* eslint-disable */
import React from 'react';
import { useNavigate } from "react-router-dom";
import ItemFilme from '../components/itemfilme';
import Header from '../layout/Header';
import ContainerCard from '../components/containercard';
import Filter from '../components/filters/filter';
import FilterOrderBy from '../components/filters/filterorderby';
import FilterCategory from '../components/filters/filtercategory';
import FilterReview from '../components/filters/filterreview';
import FilterStreaming from '../components/filters/filterstreaming';
import FilterYear from '../components/filters/filteryear';




function Filmes() {
    const history = useNavigate();

    return (
        <div>
            <Header></Header>
            <ContainerCard>
                <div className="flex flex-col my-20">
                    <button className="text-white" onClick={() => navigate(-1)}>Back</button>
                    <h1 className="text-white text-4xl font-bold text-allign">Filmes</h1>
                </div>
                <Filter>
                    <FilterOrderBy></FilterOrderBy>
                    <FilterCategory></FilterCategory>
                    <FilterReview></FilterReview>
                    <FilterStreaming></FilterStreaming>
                    <FilterYear></FilterYear>
                </Filter>
                <ItemFilme></ItemFilme>
            </ContainerCard>
        </div>
  );
}

export default Filmes;
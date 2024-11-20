/* eslint-disable */
import React from 'react';
import { useNavigate } from "react-router-dom";
import ItemFilme from '../components/itemfilme';
import ContainerCard from '../components/containercard';
import Filter from '../components/filters/filter';
import DropDownSelect from '../components/filters/dropdownselect';
import FilterCategory from '../components/filters/filtercategory';
import FilterReview from '../components/filters/filterreview';
import FilterStreaming from '../components/filters/filterstreaming';
import FilterYear from '../components/filters/filteryear';
import NavigationTitle from '../components/navigationtitle';




function Filmes() {
    const history = useNavigate();

    return (
        <div>
            <ContainerCard>
                <NavigationTitle title={"filmes"} />
                <Filter>
                    <DropDownSelect />
                    <FilterCategory />
                    <FilterReview />
                    <FilterStreaming />
                    <FilterYear />
                </Filter>
                <ItemFilme />
            </ContainerCard>
        </div>
    );
}

export default Filmes;
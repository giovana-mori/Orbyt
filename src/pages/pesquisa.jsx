/*eslint-disable*/
import React from 'react';
import NavigationTitle from '../components/navigationtitle';
import ContainerCard from '../components/containercard';
import { Link } from "react-router-dom";
import MovieCatalog from '../components/categorycatalog';
import ItemFilme from '../components/itemfilme';

function Pesquisa() {
    return (
        <div>
            <ContainerCard>
                <NavigationTitle title={"Resultados para: Sua pesquisa"} />
                <div className="flex flex-col gap-4">
                    <Link
                        to="/filmes"
                        className="grid text-white font-normal hover:underline font-bebas leading-[normal] text-2xl text-right justify-end"
                    >
                        Pesquisa avançada
                    </Link>
                    <MovieCatalog>
                        <ItemFilme /> {/*item teste ate formulaçao do outro componente*/}
                    </MovieCatalog>
                </div>
                
            </ContainerCard>
        </div>
    );
}

export default Pesquisa;
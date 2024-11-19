/*eslint-disable*/
import React from "react";

const orderby = [
    {id: 0, name: "Ordenar"},
    {id: 1, name: "Mais recentes"}, 
    {id: 2, name: "Mais antigos"}, 
    {id: 3, name: "A-Z"},
    {id: 4, name: "Z-A"},
    {id: 5, name: "Maior nota"},
    {id: 6, name: "Menor nota"},
    {id: 7, name: "Nº de avaliações"}];

function FilterOrderBy() {
    return(
        <div>
            <select name="filter" id="filter" className="flex rounded-md border bg-black">
                {orderby.map((item, index) => (
                    <option key={index} value={item.id}>{item.name}</option>
                ))}
            </select>
        </div>
    );
}

export default FilterOrderBy;
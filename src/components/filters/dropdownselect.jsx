/*eslint-disable*/
import React, {useState} from "react";

const orderby = [
    {id: 0, name: "Ordenar", value: "orderby"},
    {id: 1, name: "Mais recentes", value: "orderby"}, 
    {id: 2, name: "Mais antigos", value: "orderby"}, 
    {id: 3, name: "A-Z", value: "orderby"},
    {id: 4, name: "Z-A", value: "orderby"},
    {id: 5, name: "Maior nota", value: "orderby"},
    {id: 6, name: "Menor nota", value: "orderby"},
    {id: 7, name: "Nº de avaliações", value: "orderby"}];

const dropdownSelectOptions = [
    
]

function DropDownSelect({id, value, name}) {
    return(
        <div>
            <select name={name} id={id} value={value} className="bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 font-semibold mx-auto gap-2">
                {orderby.map((item, index) => (
                    <option key={index} value={item.id}>{item.name}</option>
                ))}
            </select>
        </div>
    );
}

export default DropDownSelect;
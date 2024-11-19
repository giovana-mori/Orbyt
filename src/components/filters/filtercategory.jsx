/*eslint-disable*/
import React from 'react';
import { useState } from 'react'; //mantem a checkbox selecionada
import Select from 'react-select';

const category = [
    {id: 0, value:"category1", label: "Categoria"},
    {id: 1, value:"category2", label: "Ação"},
    {id: 2, value:"category3", label: "Animação"},
    {id: 3, value:"category4", label: "Aventura"},
    {id: 4, value:"category5", label: "Comédia"},
    {id: 5, value:"category6", label: "Documentário"},
    {id: 6, value:"category7", label: "Drama"},
    {id: 7, value:"category8", label: "Fantasia"},
    {id: 8, value:"category9", label: "Ficção científica"},
    {id: 9, value:"category10", label: "Musical"},
    {id: 10, value:"category11", label: "Romance"},
    {id: 11, value:"category12", label: "Suspense"},
    {id: 12, value:"category13", label: "Terror"},
    {id: 13, value:"category14", label: "Western"}
];

function FilterCategory() {
    const [state, setState] = useState({ optionSelected: null });

    const handleChange = (selected) => {
        setState({
            optionSelected: selected
        });
    };

    return (
        <div>
            <Select 
                options={category}
                isMulti
                closeMenuOnSelect={false}
                hideSelectedOptions={true}
                onChange={handleChange}
                value={state.optionSelected}/>
        </div>
    );
    
};

export default FilterCategory;
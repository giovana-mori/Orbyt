/*eslint-disable*/
import React from 'react';
import { useState } from 'react'; //mantem a checkbox selecionada
import Select from 'react-select';

const category = [
    {id: 0, value:"stream1", label: "Netflix"},
    {id: 1, value:"stream2", label: "Amazon Prime Video"},
    {id: 2, value:"stream3", label: "Disney+"},
    {id: 3, value:"stream4", label: "HBO Max"},
    {id: 4, value:"stream5", label: "Globo Play"},
    {id: 5, value:"stream6", label: "Telecine"},
    {id: 6, value:"stream7", label: "Apple TV"},
    {id: 7, value:"stream8", label: "Paramount+"},
    {id: 8, value:"stream9", label: "Looke"},
    {id: 9, value:"stream10", label: "Mubi"},
    {id: 10, value:"stream11", label: "Crunchyroll"},
    {id: 11, value:"stream12", label: "Funimation"},
    {id: 12, value:"stream13", label: "Oldflix"},
    {id: 13, value:"stream14", label: "Cinema Virtual"}
];

function FilterStreaming() {
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

export default FilterStreaming;
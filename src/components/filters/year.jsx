/*eslint-disable*/
import React from 'react';
import YearInput from './dropdowns/yearinput';

function Year() {

    const handleChange = (selected) => {
        console.log('Ano selecionado:', selected);
      };
      
    return (
        <div className="p-4">
          <YearInput title={"Ano de lançamento"} onChange={handleChange} />
        </div>
      );
}

export default Year;
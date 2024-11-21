/*eslint-disable*/
import React from 'react';
import RangeInput from './dropdowns/range';

function Review(){

    const handleChange = (selected) => {
        console.log('Avaliações selecionadas:', selected);
      };

    return(
        <div className="p-4">
            <RangeInput title={"Avaliação"} onChange={handleChange}></RangeInput>
        </div>
    );
}

export default Review;
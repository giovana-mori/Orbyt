/*eslint-disable*/
import React from 'react';

function FilterYear({}) {
    return (
        <div>
            <label htmlFor="year" className="my-1 flex">
                Ano
            </label>
            <input
                type="number"
                id="year"
                name="year"
                className="flex rounded-md border bg-black"
            />
        </div>
    );
}

export default FilterYear;
/*eslint-disable*/
import React from 'react';

function FilterYear({}) {
    return (
        <div className="bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 font-semibold mx-auto gap-2">
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
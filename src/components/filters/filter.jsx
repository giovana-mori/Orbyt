/*eslint-disable*/
import React from 'react';

function Filter({ children }) {
    return <nav className='flex-col justify-center'>
                <h1 className="pl-24 uppercase text-white font-bebas text-2xl">Filtros:</h1>
                <ul className="flex space-x-3 mx-auto justify-center">
                    { children }
                </ul>
                <hr class="w-50 h-1 mx-auto my-4 bg-white border border-white rounded "></hr>
           </nav>;
}

export default Filter;
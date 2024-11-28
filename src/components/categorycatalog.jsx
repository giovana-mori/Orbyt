/*eslint-disable*/
import React from 'react';

function MovieCatalog({ children }) {
    return <section className='flex-col justify-center my-3'>
                <ul className="flex flex-wrap gap-3 justify-center">
                    { children }
                </ul>
           </section>;
}

export default MovieCatalog;
/*eslint-disable*/
import React from 'react';

function Filter({ children }) {
    return <nav>
                <ul className="flex space-x-3 mx-auto">
                    { children }
                </ul>
           </nav>;
}

export default Filter;
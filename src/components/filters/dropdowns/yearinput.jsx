/*eslint-disable*/
import React, { useState } from 'react';

const YearInput = ({ title, onChange = () => {} }) => {
    const [isOpen, setIsOpen] = useState(false);
    const [year, setYear] = useState(null);

    const handleDateChange = (year) => {
        setYear(year.target.value);
        onChange(year.target.value);
    };

    const toggleDropdown = () => setIsOpen(!isOpen);

    return (
        <div className='flex items-center '>
            <div className="relative w-44 max-w-xs">
            <button
                type="button"
                onClick={toggleDropdown}
                className="border border-white bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 mx-auto gap-2"
            >
                <div className="flex flex-wrap gap-1"> 
                    {year ? ( 
                        <span className="inline-flex items-center px-2 py-0.5 rounded-full bg-white text-black font-roboto font-semibold text-sm"> {year} </span> ) 
                        : ( 
                        <span className="text-white font-bebas text-2xl">{title}</span> 
                    )}
                </div>
            </button>

            {isOpen && (
                <div className="absolute z-10 w-full bg-black text-white font-roboto font-semibold border rounded-md shadow-lg max-w-44 justify-items-center items-center overflow-auto">
                    <label htmlFor='launchDate' className="text-white">Ano:</label>
                <div className="flex items-center px-auto py-2 max-w-44 justify-item-center">
                    
                    <input
                        id='launchDate'
                        value={year}
                        type="text"
                        onChange={handleDateChange}
                        placeholder='Digite o ano...'
                        className="text-black mx-auto bg-black text-white max-h-60 max-w-44 font-roboto font-semibold text-sm placeholder-white placeholder-opacity-50 placeholder-text-center"
                    />
                </div>
            </div>
            )}
            </div>
        </div>
    );
};

export default YearInput;

/*eslint-disable*/
import React, { useState } from 'react';

const RangeInput = ({ title, onChange = () => {} }) => {
    const [isOpen, setIsOpen] = useState(false);
    const [fromReview, setFromReview] = useState(0);
    const [toReview, setToReview] = useState(0);

    const toggleDropdown = () => setIsOpen(!isOpen);

    const handleFromReviewChange = (fromReview) => {
        setFromReview(fromReview.target.value);
        onChange(fromReview.target.value);
    };

    const handleToReviewChange = (toReview) => {
        setToReview(toReview.target.value);
        onChange(toReview.target.value);
    };

    return (
        <div className='flex items-center '>
            <div className="relative w-44 max-w-xs">
            <button
                type="button"
                onClick={toggleDropdown}
                className="border border-white bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 mx-auto gap-2"
            >
                <div className="flex flex-wrap gap-1"> 
                    {fromReview ? ( 
                        <span className="inline-flex items-center px-2 py-0.5 rounded-full bg-white text-black font-roboto font-semibold text-sm"> De: {fromReview} Até: {toReview} </span> ) 
                        : ( 
                        <span className="text-white font-bebas text-2xl">{title}</span> 
                    )}
                </div>
            </button>

            {isOpen && (
                <div className="absolute z-10 w-full bg-black text-white font-roboto font-semibold border rounded-md shadow-lg max-h-60 w-full justify-items-center items-center overflow-auto">
                <div className="flex-col items-center px-4 py-2">
                    <div>
                        <label>De:</label>
                        <br></br>
                        <input 
                            type='range' 
                            min={0} 
                            max={5} 
                            step={1} 
                            value={fromReview} 
                            onChange={handleFromReviewChange}
                            className="w-full"
                        />
                    </div>
                    <br></br>
                    <div>
                        <label>Até:</label>
                        <br></br>
                        <input 
                            type='range' 
                            min={0} 
                            max={5} 
                            step={1} 
                            value={toReview}
                            className="w-full"
                            onChange={handleToReviewChange}
                        />
                    </div>
                </div>
            </div>
            )}
            </div>
        </div>
    );
};

export default RangeInput;

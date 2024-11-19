/*eslint-disable*/
import React, {useState} from 'react';

function FilterReview(){

    const [review1, setReview1] = useState(0);
    const [review2, setReview2] = useState(0);

    return(
        <div className="bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 font-semibold mx-auto gap-2">
            <label htmlFor='review' className="text-white">De:</label>
            <h1 className='text-white'>{review1}</h1>
            <input type='range' min={0} max={5} step={1} value={review1} onChange={(e)=>setReview1(e.target.value)} className="w-full" />
            <label htmlFor='review' className="text-white">Até:</label>
            <h1 className='text-white'>{review2}</h1>
            <input type='range' min={0} max={5} step={1} value={review2} onChange={(e)=>setReview2(e.target.value)} className="w-full" />
        </div>
    );
}

export default FilterReview;
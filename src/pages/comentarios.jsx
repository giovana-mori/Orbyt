import React from 'react';

function MovieReview() {
  return (
    <div className="container mx-auto px-4 py-8">
      <div className="flex flex-col items-center">
        <div className="relative h-96 w-64">
          <img src="https://via.placeholder.com/600x900.png" alt="Oppenheimer Poster" className="h-full w-full object-cover rounded-lg" />
          <div className="absolute bottom-4 left-4">
            <img src="https://via.placeholder.com/150x150.png" alt="Oppenheimer Logo" className="h-16 w-16 object-cover rounded-full" />
          </div>
        </div>
        <h1 className="text-4xl font-bold mt-4">Oppenheimer</h1>
        <div className="flex space-x-4 mt-2">
          <div className="bg-gray-800 rounded-md px-3 py-1">Suspense</div>
          <div className="bg-gray-800 rounded-md px-3 py-1">Obra da época</div>
          <div className="bg-gray-800 rounded-md px-3 py-1">3h 0m</div>
        </div>
        <div className="flex items-center mt-4">
          <span className="text-xl font-bold">5.0</span>
          <svg className="h-5 w-5 text-yellow-400" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 17.27L18.18 21 16.54 13.97 22 9.24 14.81 8.63 12 2 9.19 8.63 2 9.24 7.46 13.97 5.82 21 12 17.27z" />
          </svg>
        </div>
        <p className="mt-4 text-center">Uma visão fascinante da vida de J. Robert Oppenheimer, o pai da bomba atômica.</p>
      </div>
    </div>
  );
}

export default MovieReview;

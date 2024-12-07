import React from "react";

function CardFilme({
  title, year, image, score, overview,
}) {
  return (
    <div className="flex max-w-lg bg-black text-white rounded-lg shadow-lg p-4 border border-gray-800">
      <img
        src={`http://image.tmdb.org/t/p/w500/${image}`}
        alt="Oppenheimer Poster"
        className="rounded-lg w-36 h-auto"
      />
      <div className="ml-4 flex flex-col justify-between">
        <div>
          <h2 className="text-2xl font-bold">{title}</h2>
          <p className="text-gray-400 text-lg">{year}</p>
          <div className="flex items-center mt-2">
            <div className="flex text-yellow-400">
              {Array(5)
                .fill()
                .map(() => (
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="currentColor"
                    viewBox="0 0 24 24"
                    className="w-5 h-5"
                  >
                    <path d="M12 .587l3.668 7.568 8.332 1.151-6.064 5.978 1.431 8.291L12 18.896l-7.367 4.679 1.431-8.291-6.064-5.978 8.332-1.151z" />
                  </svg>
                ))}
            </div>
            <div className="bg-gray-700 text-white text-sm font-bold py-0.5 px-2 rounded-lg ml-2">
              {score}
            </div>
          </div>
        </div>
        <p className="text-gray-300 mt-2">
          {overview}
        </p>
      </div>
    </div>
  );
}

export default CardFilme;

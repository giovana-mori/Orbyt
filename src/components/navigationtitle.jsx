import React from "react";
import { useNavigate } from "react-router-dom";

export default function NavigationTitle({ title }) {
  const navigate = useNavigate();

  const handleGoBack = () => {
    navigate('/filmes');
  };

  return (
    <div className="flex items-center justify-between pt-4 pb-12">
      <button type="button" title="Voltar" onClick={handleGoBack}>
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          strokeWidth="4"
          stroke="white"
          className="size-12"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M15.75 19.5 8.25 12l7.5-7.5"
          />
        </svg>
        {}
      </button>
      <h1 className="uppercase text-white font-bebas text-6xl">{title}</h1>
      <div className="w-12" />
    </div>
  );
}

import React, { useState } from "react";
import { Link, Navigate } from "react-router-dom";

function Navbar() {
  const [searchDetails, setSearchDetails] = useState({ text: "" });
  const [search, setSearch] = useState(null);

  const changeHandler = (e) => {
    if (searchDetails != null) {
      const { name, value } = e.target;
      setSearchDetails((prevDetails) => ({ ...prevDetails, [name]: value }));
    }
  };

  const submitHandler = async () => {
    if (searchDetails.text.trim() !== "") {
      setSearch(searchDetails);
    }
  };

  return (
    <nav className="bg-black shadow-md">
      <div className="container mx-auto flex items-center max-w-7xl justify-between py-2 px-4">
        <Link to="/">
          <div className="flex items-center gap-1">
            <img src="img/logo_nav.png" alt="Logo" className="h-20" />
            <img src="img/text_svg_nav.svg" alt="Logo" className="w-32" />
          </div>
        </Link>
        <div className="flex items-center mx-4 gap-2 flex-1 max-w-lg justify-center">
          <div className="relative w-full max-w-lg">
            <form onSubmit={submitHandler}>
              <input
                type="text"
                name="text"
                value={searchDetails.text}
                onChange={changeHandler}
                placeholder="Busca..."
                className="w-full text-black text-base rounded-full py-0.5 pr-10 pl-2 bg-gray-200 focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              <svg
                className="absolute top-2 right-1.5 w-3 h-3 text-gray-500"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 20 20"
              >
                <path
                  stroke="currentColor"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
                />
                <input type="submit" />
              </svg>
            </form>
            {search && <Navigate to="/pesquisa" state={search} replace />}
          </div>
        </div>
        <div className="flex space-x-6">
          <Link
            to="login"
            className="text-white font-bebas bg-primary hover:bg-opacity-35 font-medium rounded-lg  tracking-wider text-xl px-4 py-1 text-center"
          >
            ENTRAR
          </Link>
          <Link
            to="/registro"
            className="text-white font-normal hover:underline font-bebas leading-[normal] text-2xl text-right"
          >
            CRIAR CONTA
          </Link>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

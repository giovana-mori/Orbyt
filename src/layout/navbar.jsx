import React, { useEffect, useState } from "react";
import { Link, Navigate } from "react-router-dom";
import { useAuth } from "../utils/authContext";
import API from "../utils/API";

function Navbar() {
  const [searchDetails, setSearchDetails] = useState({ text: "" });
  const { user } = useAuth();
  const [users, setUsers] = useState([]);
  const userId = localStorage.getItem("user");
  const fetchUsers = () => {
    API.get(`/Usuarios/${userId}`).then((response) => setUsers({ ...response.data, key: `user-${response.data.id}` }));
  };
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
  useEffect(() => { fetchUsers(); }, []);
  return (
    <nav className="bg-black shadow-md">
      <div className="container mx-auto flex items-center justify-between py-2">
        <Link to="/">
          <div className="flex items-center gap-1">
            <img src="/img/logo_nav.png" alt="Logo" className="h-20" />
            <img src="/img/text_svg_nav.svg" alt="Logo" className="w-32" />
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
                className="w-full text-black text-base border-2 border-primary py-1.5 rounded-md pr-10 pl-2 bg-gray-200"
              />
              <svg
                className="absolute top-2 right-2 w-4 h-6 text-gray-500"
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
          {user ? (
            <Link
              to="/login"
              className="text-white transition-all font-bebas bg-primary hover:bg-opacity-35 font-medium rounded-lg  tracking-wider text-xl px-4 py-1 text-center"
            >
              ENTRAR
            </Link>
          ) : <Link className="text-white" to="/perfil">{users.nome}</Link> }
        </div>
      </div>
      <div className="bg-[#5e52aa33]">
        <div className="container mx-auto flex items-center justify-evenly gap-[2%] py-2">
          {[
            {
              key: React.key,
              label: "POPULARES",
              value: "popular",
            },
            {
              key: React.key,
              label: "EM-CARTAZ",
              value: "now_playing",
            },
            {
              key: React.key,
              label: "LANÇAMENTOS",
              value: "upcoming",
            },
            {
              key: React.key,
              label: "MELHOR-AVALIADOS",
              value: "top_rated",
            },
          ].map((label, value, key) => (
            <Link
              key={key}
              to={`genero/${label.value}`}
              className="text-white font-normal hover:underline font-bebas leading-[normal] text-xl text-left tracking-wide"
            >
              {label.label}
            </Link>
          ))}
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

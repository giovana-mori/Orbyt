import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Perfil from "./pages/perfil";
import "./output.css";
import Login from "./pages/login";
import ConfigPerfil from "./pages/configperfil";
import Layout from "./layout/layout";
import Filmes from "./pages/filmes";
import Home from "./pages/home";
import Register from "./pages/register";
import Pesquisa from "./pages/pesquisa";
import Sobre from "./pages/sobre";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/perfil" element={<Perfil />} />
          <Route path="/login" element={<Login />} />
          <Route path="/registro" element={<Register />} />
          <Route path="/configuracoes" element={<ConfigPerfil />} />
          <Route path="/filmes" element={<Filmes />} />
          <Route path="/genero/:slug" element={<Filmes />} />
          <Route path="/sobre/:slug" element={<Sobre />} />
          <Route path="/pesquisa" element={<Pesquisa />} />
          {/* apenas teste */}
          <Route path="/" element={<Home />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>,
);

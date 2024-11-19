/* eslint-disable */

import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import App from "./App";
import Header from "./layout/Header";
import "bootstrap/dist/css/bootstrap.min.css";
import Perfil from "./pages/perfil";
import "./output.css";
import Login from "./pages/login";
import ConfigPerfil from "./pages/configperfil";
import Layout from "./layout/layout";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/perfil" element={<Perfil />} />
          <Route path="/login" element={<Login />} />
          <Route path="/configuracoes" element={<ConfigPerfil />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);

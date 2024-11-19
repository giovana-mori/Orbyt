import React from "react";
import NavigationTitle from "../components/navigationtitle";
import ContainerCard from "../components/containercard";
import Avatar from "../components/avatar";
import MenuPerfil from "../components/menuperfil";
import InputLabel from "../components/forms/inputlabel";

function ConfigPerfil() {
  return (
    <div>
      <ContainerCard>
        <NavigationTitle title="Perfil do Usuário" />
        <div className="grid grid-cols-1 md:grid-cols-4 gap-10">
          <div className="border-r-2 md:border-r-2 md:col-span-1">
            <div className="flex items-center px-4">
              <Avatar />
            </div>
            <MenuPerfil />
          </div>
          <div className="md:col-span-3">
            <h2 className="text-4xl text-white font-bebas mb-4">
              Configurações
            </h2>
            <form action="">
              <InputLabel
                id="nome"
                name="nome"
                label="Nome Completo"
                type="text"
                placeholder="Digite o seu nome completo"
              />
              <InputLabel
                id="usuario"
                name="usuario"
                label="Nome de Usuário"
                type="text"
                placeholder="Digite o seu nome de usuário"
              />
              <InputLabel
                id="celular"
                name="celular"
                label="Celular"
                type="tel"
                placeholder="Digite o seu celular"
              />
              <InputLabel
                id="email"
                name="email"
                label="Email"
                type="email"
                placeholder="Digite o seu email"
              />
              <InputLabel
                id="senha"
                name="senha"
                label="Senha"
                type="password"
                placeholder="Digite a sua nova senha"
              />
              <button
                type="submit"
                className="text-black bg-white hover:bg-violet-700 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center "
              >
                Salvar
              </button>
            </form>
          </div>
        </div>
      </ContainerCard>
    </div>
  );
}
export default ConfigPerfil;

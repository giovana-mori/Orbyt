import React from "react";
import Form from "../components/forms/form";
import FormItem from "../components/forms/inputlabel";

export default function Login() {
  return (
    <div className="bg-black-50 relative flex min-h-screen overflow-hidden bg-black">
      <img
        src="https://gizmodo.uol.com.br/wp-content/blogs.dir/8/files/2022/07/Nebulosa-Carina.png"
        alt=""
        className="absolute left-1/2 top-1/2 max-w-100px -translate-x-1/2 -translate-y-1/2"
        width="1308"
      />
      <div className="relative flex bg-black px-6 pb-8 pt-40 opacity-90 shadow-xl ring-1 ring-gray-900/5 sm:max-w-lg sm:rounded-lg sm:px-12">
        <div className="mx-auto max-w-md">
          <h1 className="flex justify-start text-3xl text-white">Login</h1>
          <div className="divide-y-2 divide-gray-300/50">
            <div className="space-y-6 py-8 text-base leading-7 text-white">
              <Form>
                <FormItem label="Usuario" name="user" id="user" />
                <FormItem
                  label="Senha"
                  name="password"
                  id="password"
                  type="password"
                />
              </Form>
              <a href="/" className="text-sm text-sky-500 hover:text-sky-600">
                Esqueci minha senha
              </a>
              <div>
                <button type="submit" className="w-full text-white bg-black border border-white hover:bg-gray-800 focus:ring-4 focus:outline-none focus:ring-white font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-black dark:hover:bg-gray-700 dark:focus:ring-white">Enviar</button>
              </div>
            </div>
            <div className="pt-5 text-base font-semibold leading-7">
              <p className="text-white">Não possui uma conta?</p>
              <p>
                <a href="./registro" className="text-sky-500 hover:text-sky-600">Crie uma</a>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx,css}", // Ajuste os caminhos conforme sua estrutura
  ],
  theme: {
    extend: {
      colors: {
        bordagray: '#858585', // Exemplo de cor personalizada
        fundocards: '#181818', // Exemplo de cor personalizada
      },
      fontFamily: {
        bebas: ['"Bebas Neue"', 'cursive'],
        roboto: ['Roboto', 'sans-serif'],
      },
    },
  },
  plugins: [],
};

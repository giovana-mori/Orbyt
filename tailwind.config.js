/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx,css}", // Ajuste os caminhos conforme sua estrutura
  ],
  theme: {
    extend: {
      colors: {
        primary: '#5f53ab', // Exemplo de cor personalizada
        secondary: '#0754a8', // Exemplo de cor personalizada
        light: '#00d0e9',
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

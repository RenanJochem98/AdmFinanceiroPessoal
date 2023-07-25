/** @type {import('tailwindcss').Config} */
export default {
  content: ["./src/**/*.{js,jsx,ts,tsx}"],
  theme: {
    extend: {
      colors: {
        'primaria': '#00265c',
        'secundaria': '#0090ff',
        'destaque': '#00bf6f',
        'aviso': '#ffc107',
        'perigo': '#ff4f42',
        'destaque-secundaria': '#fa8c16',
      }
    }
  },
  extend: {},
  plugins: [],
}


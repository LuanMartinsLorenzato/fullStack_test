/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,jsx,ts,tsx,vue}', './pages/**/*.{html,js}'],
  theme: {
    screens: {
      sm: '628px',
      md: '768px', 
      lg: '1024px',
      xl: '1280px'
    },
    extend: {}
  },
  plugins: []
}

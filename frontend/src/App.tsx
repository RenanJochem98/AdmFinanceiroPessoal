// import { useState } from 'react'
import './App.css'
import BtnHeader  from './Components/BtnHeader'

function App() {
  // const [count, setCount] = useState(0)

  return (
    <div className='bg-gradient-to-r from-primaria  via-secundaria to-primaria'>
      <header>
        <div className='text-center font-bold text-primaria w-full p-4 text-xl shadow-md shadow-black/30'>
           Administrador Financeiro Pessoal
        </div>
      </header>
      <main>
        <nav className='mx-auto flex items-center justify-between p-6'>
          <BtnHeader texto="Adicionar entrada" />
          <BtnHeader texto="Adicionar Saída"/>
        </nav>
        Hello World, de novo
      </main>
      <footer>
        Footer
      </footer>
    </div>
  )
}

export default App

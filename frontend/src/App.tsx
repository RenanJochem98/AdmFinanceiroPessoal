// import { useState } from 'react'
import './App.css'
import Header  from './Components/Header'
import BtnHeader  from './Components/BtnHeader'
import Contas from './Components/Contas'

function App() {
  // const [count, setCount] = useState(0)

  return (
    <div>
      <Header />
      <main className="bg-slate-200">
        <nav className='mx-auto flex items-center justify-between p-6'>
          <BtnHeader texto="Adicionar entrada" />
          <BtnHeader texto="Adicionar Saída"/>
        </nav>
        Hello World, de novo
        <Contas />
      </main>
      <footer className='fixed bottom-0 text-center font-bold bg-gradient-to-r from-primaria  via-secundaria to-primaria
         text-primaria w-full p-4 text-xl shadow-md shadow-black/30'>
        Footer
      </footer>
    </div>
  )
}

export default App

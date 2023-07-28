// import { useState } from 'react'
import './App.css'
import Header  from './Components/Header'
import BtnHeader  from './Components/BtnHeader'

function App() {
  // const [count, setCount] = useState(0)

  return (
    <div>
      <Header />
      <main className="">
        <nav className='mx-auto flex items-center justify-between p-6'>
          <BtnHeader texto="Adicionar entrada" />
          <BtnHeader texto="Adicionar Saída"/>
        </nav>
        Hello World, de novo
      </main>
      <footer className='fixed bottom-0 text-center font-bold bg-gradient-to-r from-primaria  via-secundaria to-primaria
         text-primaria w-full p-4 text-xl shadow-md shadow-black/30'>
        Footer
      </footer>
    </div>
  )
}

export default App

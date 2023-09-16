
import BtnHeader  from '../Components/BtnHeader'
import Contas from '../Components/Contas'

export default function Home() {
  // const [count, setCount] = useState(0)

  return (
    <div>
        <nav className='mx-auto flex items-center justify-between p-6'>
          <BtnHeader texto="Adicionar entrada" />
          <BtnHeader texto="Adicionar Saída"/>
        </nav>
        Hello World, de novo
        <Contas />
    </div>
  )
}

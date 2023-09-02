import * as React from "react"
import InputDate from "./Inputs/InputDate"
import InputNumber from "./Inputs/InputNumber"
import Modal from "./Modal"
import Select from "./Select"

interface BtnHeaderProps {
    texto: string
}

export default function BtnHeader( {texto}: BtnHeaderProps ) {
    
    const [isOpen, setIsOpen] = React.useState(false)
    return (
        <>
            <button
                type="button"
                className="mx-auto font-bold text-blue-800 p-2 rounded-md bg-slate-400
                hover:bg-gray-600 hover:text-blue-400"
                onClick={() => setIsOpen(!isOpen)} >
                    {texto}
            </button>
            <Modal isOpen={isOpen} setModalOpen={() => setIsOpen(!isOpen)} title="Adicionar Entrada">
                <div className="flex items-center p-5">
                    {/* <div className="text-center">Terste</div> */}
                    <form>
                        <InputNumber placeholder="Valor"/>
                        <InputDate placeholder="Data"/>
                        <Select placeholder="Conta" options={[
                            {text: "Mercado Pago", value: 1},
                            {text: "Nubank", value: 2},
                            {text: "BTG Banco", value: 3},
                            {text: "BTG Corretora", value: 4},
                        ]}/>
                    </form>
                </div>
            </Modal>
        </>
        
    )
}
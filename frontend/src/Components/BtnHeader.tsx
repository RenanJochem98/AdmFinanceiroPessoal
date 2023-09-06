import * as React from "react"
import ProfitFormModal from "./Modals/ProfitFormModal"

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
            <ProfitFormModal isOpen={isOpen} setModalOpen={() => {setIsOpen(!isOpen)}} />
        </>
        
    )
}
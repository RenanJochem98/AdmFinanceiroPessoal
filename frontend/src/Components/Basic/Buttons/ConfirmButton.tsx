import DefaultButton from "./DefaultButton"

interface ConfirmButtonProps {
    onClick: () => void
}

export default function ConfirmButton( {onClick}: ConfirmButtonProps ) {
    
    return (
        <DefaultButton text="Confirmar" color="bg-green-500 hover:bg-green-800 text-white" 
        onClick={onClick}/>
    )
}
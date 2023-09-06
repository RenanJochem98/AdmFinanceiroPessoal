import DefaultButton from "./DefaultButton"

interface CloseButtonProps {
    onClick: () => void
}

export default function CloseButton( {onClick}: CloseButtonProps ) {
    
    return (
        <DefaultButton text="Fechar" color="bg-red-500 hover:bg-red-800 text-white" 
        onClick={onClick}/>
    )
}
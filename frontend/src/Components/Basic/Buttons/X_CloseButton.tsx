import DefaultButton from "./DefaultButton"

interface CloseButtonProps {
    onClick: () => void
}

export default function X_CloseButton( {onClick}: CloseButtonProps ) {
    
    return (
        <DefaultButton 
            text="X" 
            color="bg-red-500 hover:bg-red-800 text-white absolute right-1 top-0" 
            onClick={onClick}
        />
    )
}
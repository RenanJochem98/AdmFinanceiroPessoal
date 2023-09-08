import { IDefaultButton } from "../../../types/IDefaultButton"
import DefaultButton from "./DefaultButton"

interface CloseButtonProps extends IDefaultButton {
}

export default function CloseButton( {...rest}: CloseButtonProps ) {
    
    return (
        <DefaultButton 
            {...rest}
            text="Fechar"
            className="bg-red-500 hover:bg-red-800 text-white" />
    )
}
import { IDefaultButton } from "../../../types/IDefaultButton"
import DefaultButton from "./DefaultButton"

interface ConfirmButtonProps extends IDefaultButton {
    
}

export default function ConfirmButton( {...rest}: ConfirmButtonProps ) {
    
    return (
        <DefaultButton 
            {...rest}
            text="Confirmar"
            className={"bg-green-500 hover:bg-green-800 text-white px-4 py-3 " + rest.className} 
        />
    )
}
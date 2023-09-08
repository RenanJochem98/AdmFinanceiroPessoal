import { IDefaultButton } from "../../../types/IDefaultButton"
import DefaultButton from "./DefaultButton"

interface CloseButtonProps extends IDefaultButton {
}

export default function X_CloseButton( {...rest}: CloseButtonProps ) {
    
    return (
        <DefaultButton 
            {...rest}
            text="X" 
            className="bg-red-500 hover:bg-red-800 text-white absolute right-1 top-0" 
        />
    )
}
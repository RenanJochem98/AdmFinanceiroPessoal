
// interface DefaultButtonProps {
//     text: string,
//     color?: string,
//     onClick: () => void
// }

import { IDefaultButton } from "../../../types/IDefaultButton"

export default function DefaultButton( { ...rest}: IDefaultButton ) {
    const defaultClassName = rest.className == null 
                            ? 'text-blue-800 bg-slate-400 hover:bg-gray-600 hover:text-blue-400' 
                            : rest.className
                            
    return (
        <>
            <button
                {...rest}
                type="button"
                className= {'mx-auto font-bold  px-2 py-1 rounded-md ' + defaultClassName} >
                    {rest.text}
            </button>
        </>
        
    )
}
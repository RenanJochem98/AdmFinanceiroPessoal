// import * as React from "react"

import { ReactNode } from "react"
import X_CloseButton from "../Buttons/X_CloseButton"

// import X_CloseButton from "./Buttons/X_CloseButton"

interface IModalProps {
    isOpen: boolean,
    setModalOpen: () => void,
    title?: string,
    children?: string | JSX.Element
    buttons?: ReactNode | Array<ReactNode>
}

export default function Modal({isOpen, title, children, setModalOpen }: IModalProps) {
    const backgroundStyles : React.CSSProperties = {
        position: 'fixed',
        top: '0',
        bottom: '0',
        left: '0',
        right: '0',
        backgroundColor: 'rgb(0,0,0,0.5)',
        zIndex: '1000'
    }

    const modalStyles: React.CSSProperties = {
        position: 'fixed',
        top: '40%',
        left: '50%',
        transform: 'translate(-50%,-50%)',
        padding: '15px',
        backgroundColor: '#fff',
        borderRadius: '10px',
        color: '#000',
        boxShadow: '.5rem 5px 5px rgb(0,0,0,0.3)'
    }

    return isOpen ? 
        <>
            <div style={backgroundStyles}>
                <div style={modalStyles}>
                    {/* Header */}
                    <div className="text-center justify-between top-0 pb-3 relative">
                        <div>
                            <p className="font-bold">{title}</p>
                        </div>
                        
                        <X_CloseButton onClick={setModalOpen}/>
                    </div>
                    <div>
                        {children}
                    </div>
                    {/* Footer */}
                    {/* <div className="flex items-center justify-between pt-6 space-x-2"> */}
                        {/* <CloseButton onClick={setModalOpen}/> */}
                        {/* {buttons} */}
                    {/* </div> */}
                </div>
                
            </div>
        </>
    : <></>
}
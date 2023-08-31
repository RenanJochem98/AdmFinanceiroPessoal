// import * as React from "react"

import CloseButton from "./Buttons/CloseButton"

interface ModalProps {
    isOpen: boolean,
    setModalOpen: () => void
}

export default function Modal({isOpen, setModalOpen }:ModalProps) {
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
        top: '50%',
        left: '50%',
        transform: 'translate(-50%,-50%)',
        padding: '150px',
        backgroundColor: '#fff',
        borderRadius: '10px',
        color: '#000'
    }

    return isOpen ? 
        <>
            <div style={backgroundStyles}>
                <div style={modalStyles}>
                    {/* Header */}
                    <div>

                    </div>
                    <div>
                        Um Dialog aqui
                    </div>
                    {/* Footer */}
                    <div>
                        <CloseButton onClick={setModalOpen}/>
                    </div>
                </div>
                
            </div>
        </>
    : null
}
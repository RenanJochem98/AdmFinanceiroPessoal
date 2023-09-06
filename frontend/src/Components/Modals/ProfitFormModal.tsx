
// import CloseButton from "../Basic/Buttons/CloseButton";
// import ConfirmButton from "../Basic/Buttons/ConfirmButton";
import Modal from "../Basic/Modal/Modal";
import ProfitForm from "../Forms/ProfitForm";

interface IProfitFormModalProps{
    isOpen: boolean,
    setModalOpen: () => void 
}

export default function ProfitFormModal({isOpen, setModalOpen}:IProfitFormModalProps){
    return (
        <Modal isOpen={isOpen} setModalOpen={setModalOpen} 
        title="Adicionar Entrada">
            <ProfitForm/>
        </Modal>
    )
}
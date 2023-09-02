import CloseButton from "../Buttons/CloseButton";
interface IModalButtonProps {
    onClick : () => void
}
export default function ModalButton({onClick}: IModalButtonProps){
    return <CloseButton onClick={onClick}/>
}
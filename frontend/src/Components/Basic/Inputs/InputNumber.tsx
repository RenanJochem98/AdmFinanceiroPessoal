interface IInputNumberProps {
    placeholder?: string
}
export default function InputNumber({ placeholder}: IInputNumberProps){
    return (
        <>
            <input
                type="number" 
                placeholder={placeholder} 
                className="border-b-2 w-full my-2"
            />
        </>
    )
}
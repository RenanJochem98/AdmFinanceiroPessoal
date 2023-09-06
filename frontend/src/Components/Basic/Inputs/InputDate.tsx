interface IInputTextProps {
    placeholder?: string
}
export default function InputDate({placeholder}: IInputTextProps){
    return (
        <>
            <input 
                type="date"
                placeholder={placeholder}
                className="border-b-2 w-full my-2"
            />
        </>
    )
}
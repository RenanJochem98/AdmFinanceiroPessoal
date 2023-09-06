interface IOption {
    text: string,
    value: number
}

interface ISelectProps {
    placeholder?: string,
    options:Array<IOption>
}
export default function Selec({ placeholder, options}: ISelectProps){
    return (
        <>
            <select className="w-full border-b-2 my-2">
                <option value="" >{placeholder}</option>
                {options.map(opt =>{
                    return <option value={opt.value}>{opt.text}</option>
                })}
            </select>
        </>
    )
}
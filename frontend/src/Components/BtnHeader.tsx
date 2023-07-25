
interface BtnHeaderProps {
    texto: string
}

export default function BtnHeader( {texto}: BtnHeaderProps ) {
    return (
        <button
            type="button"
            className="mx-auto font-bold text-blue-800 p-2 rounded-md bg-slate-400
             hover:bg-gray-600 hover:text-blue-400">
                {texto}
         </button>
    )
}

interface DefaultButtonProps {
    text: string,
    color?: string,
    onClick: () => void
}

export default function DefaultButton( {text, color, onClick}: DefaultButtonProps ) {
    const defaultColor = color == null 
                            ? 'text-blue-800 bg-slate-400 hover:bg-gray-600 hover:text-blue-400' 
                            : color
    return (
        <>
            <button
                type="button"
                className={'mx-auto font-bold  p-2 rounded-md ' + defaultColor}
                onClick={onClick} >
                    {text}
            </button>
        </>
        
    )
}
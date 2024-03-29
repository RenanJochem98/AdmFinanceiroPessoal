import {  useForm } from "react-hook-form" //SubmitHandler
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod"
import ConfirmButton from "../Basic/Buttons/ConfirmButton";
// import InputDate from "../Basic/Inputs/InputDate";
// import Select from "../Basic/Select";
// interface IProfitFormSend {
//     value: string
//     date: string
//     account: string
// }

const userAccounts = [
    {text: "Mercado Pago", value: 1},
    {text: "Nubank", value: 2},
    {text: "BTG Banco", value: 3},
    {text: "BTG Corretora", value: 4},
]

const profitFormSchema = z.object({
    value: z.string().nonempty("Campo obrigatório"), //.gte(0, "O valor deve ser maior ou igual a zero."),
    date: z.string().nonempty("Campo obrigatório"),
    account: z.string().nonempty("Campo obrigatório")
})

type ProfitFormData = z.infer<typeof profitFormSchema>

export default function ProfitForm(){
    
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<ProfitFormData>({
        resolver: zodResolver(profitFormSchema)
    })

    function onSubmit(data: object) {
        console.log("Data", data)
    }
    
    console.log("Erros: ",errors)
    return (
        <div className="flex flex-col p-5 items-center">
            {/* <div className="text-center">Terste</div> */}
            <form onSubmit={handleSubmit(onSubmit)}>
                <input type="number" placeholder="Valor" className="border-b-2 w-full mt-2 text-center" {...register("value")}/>
                {errors.value &&<span className="text-xs text-red-700 font-semibold">{errors.value?.message}</span>}
                {/* <p >Erro</p> */}
               
                <input type="date" placeholder="Data" className="border-b-2 w-full mt-2 " {...register("date")}/>
                {errors.date &&<span className="text-xs text-red-700 font-semibold">{errors.date?.message}</span>}
                
                <select className="w-full border-b-2 mt-2" {...register("account")}>
                    <option value="" key={0} >Conta</option>
                    {userAccounts.map(opt =>{
                        return <option key={opt.value} value={opt.value}>{opt.text}</option>
                    })}
                </select>
                {errors.account &&<span className="text-xs text-red-700 font-semibold">{errors.account?.message}</span>}
                
                <ConfirmButton type="submit" className="w-full mt-10 justify-center" />
            </form>
        </div>
    )
}
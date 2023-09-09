import { SubmitHandler, useForm } from "react-hook-form";
import ConfirmButton from "../Basic/Buttons/ConfirmButton";
// import InputDate from "../Basic/Inputs/InputDate";
// import Select from "../Basic/Select";

interface IProfitFormSend {
    value: string
    date: string
    account: string
}

export default function ProfitForm(){
    const userAccounts = [
        {text: "Mercado Pago", value: 1},
        {text: "Nubank", value: 2},
        {text: "BTG Banco", value: 3},
        {text: "BTG Corretora", value: 4},
    ]

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<IProfitFormSend>()

    const onSubmit: SubmitHandler<IProfitFormSend> = (data) => {
        console.log(data)
        console.log(errors)
    }

    return (
        <div className="flex flex-col p-5 items-center">
            {/* <div className="text-center">Terste</div> */}
            <form onSubmit={handleSubmit(onSubmit)}>
                <input type="number" placeholder="Valor" className="border-b-2 w-full mt-2 text-center" {...register("value", {required: true,})}/>
                {errors.value &&<span className="text-xs text-red-700 font-semibold">Este campo é obriatório.</span>}
                {/* <p >Erro</p> */}
               
                <input type="date" placeholder="Data" className="border-b-2 w-full mt-2 " {...register("date", {required: true,})}/>
                {errors.date &&<span className="text-xs text-red-700 font-semibold">Este campo é obriatório.</span>}
                
                <select className="w-full border-b-2 mt-2" {...register("account", {required: true,})}>
                    <option value="" key={0} >Conta</option>
                    {userAccounts.map(opt =>{
                        return <option key={opt.value} value={opt.value}>{opt.text}</option>
                    })}
                </select>
                {errors.account &&<span className="text-xs text-red-700 font-semibold">Este campo é obriatório.</span>}
                
                <ConfirmButton type="submit" className="w-full mt-10 justify-center" />
            </form>
        </div>
    )
}
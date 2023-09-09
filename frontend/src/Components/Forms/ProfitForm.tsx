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
        // formState: { errors },
    } = useForm<IProfitFormSend>()

    const onSubmit: SubmitHandler<IProfitFormSend> = (data) => console.log(data)

    return (
        <div className="flex flex-col p-5 items-center text-center">
                    {/* <div className="text-center">Terste</div> */}
                    <form onSubmit={handleSubmit(onSubmit)}>
                        <input type="number" placeholder="Valor" className="border-b-2 w-full my-2 " {...register("value")}/>
                        <input type="date" placeholder="Data" className="border-b-2 w-full my-2 " {...register("date")}/>
                        <select className="w-full border-b-2 my-2" {...register("account")}>
                            <option value="" key={0} >Conta</option>
                            {userAccounts.map(opt =>{
                                return <option key={opt.value} value={opt.value}>{opt.text}</option>
                            })}
                        </select>
                        <ConfirmButton type="submit" className="mt-2 justify-center" />
                    </form>
                </div>
    )
}
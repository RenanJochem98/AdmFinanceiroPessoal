import ConfirmButton from "../Basic/Buttons/ConfirmButton";
import InputDate from "../Basic/Inputs/InputDate";
import InputNumber from "../Basic/Inputs/InputNumber";
import Select from "../Basic/Select";

export default function ProfitForm(){
    return (
        <div className="flex flex-col p-5 items-center text-center">
                    {/* <div className="text-center">Terste</div> */}
                    <form>
                        <InputNumber placeholder="Valor"/>
                        <InputDate placeholder="Data"/>
                        <Select placeholder="Conta" options={[
                            {text: "Mercado Pago", value: 1},
                            {text: "Nubank", value: 2},
                            {text: "BTG Banco", value: 3},
                            {text: "BTG Corretora", value: 4},
                        ]}/>
                        <ConfirmButton className="mt-2 justify-center" onClick={() =>alert("Click")} />
                    </form>
                </div>
    )
}
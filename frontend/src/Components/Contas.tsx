//pacote nivo e react-vis para graficos não funcionam com react 18 (12/08/2023)
//https://recharts.org/en-US/api/BarChart

import CustomBarChart from "./Charts/CustomBarChart"


export default function Contas() {
    /*const listaContas = [
        {
            nome: "BTG Banking",
            valor: 10.00,
            data: "01/03/2023",
            cor: "#013275",
            valor2: [10.00]
        },
        {
            nome: "BTG Corretora",
            valor: 11.00,
            data: "01/03/2023",
            cor: "#022358",
            valor2: [11.00]
        },
        {
            nome: "Rico",
            valor: 12.00,
            data: "02/03/2023",
            cor: "#FF5200",
            valor2: [12.00]
        },
        {
            nome: "Mercado Livre",
            valor: 13.00,
            data: "02/03/2023",
            cor: "#068EE4",
            valor2: [13.00]
        }
    ]*/

    // let listaContasFormatada = {}
    // listaContas.map(v =>{
    //     listaContasFormatada[v.data] = {
    //         nome: v.nome,
    //         valor: v.valor,
    //         cor: v.cor
    //     } 
    // })
    const lista2 = [
        {
            name: "Mercado Livre",
            value: 13.00,
            date: "02/03/2023",
            color: "#068EE4",
            //valor: [13.00]
        },
        {
            name: "Mercado Livre",
            value: 14.50,
            date: "03/03/2023",
            color: "#068EE4",
            //valor: [13.00]
        },
        {
            name: "Mercado Livre",
            value: 15.00,
            date: "04/03/2023",
            color: "#068EE4",
            //valor: [13.00]
        },
        {
            name: "Mercado Livre",
            value: 12.00,
            date: "05/03/2023",
            color: "#068EE4",
            //valor: [13.00]
        },
        {
            name: "Mercado Livre",
            value: 14.00,
            date: "06/03/2023",
            color: "#068EE4",
            //valor: [13.00]
        }
    ]

    return (
        <div>
            <CustomBarChart accounts={lista2}/>
        </div>
    )
}
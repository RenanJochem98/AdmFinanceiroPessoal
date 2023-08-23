import { BarChart, Bar, Tooltip, XAxis, /*Legend,*/ YAxis } from 'recharts'

// interface IValueOnDate {
//     value: DoubleRange,
//     date: Date
// }

interface IAccount {
    name: string
    value: number,
    date: string,
    color: string
}


export default function CustomBarChart({accounts}:{accounts:IAccount[]}) {
    const currentColor = accounts[0].color
    return (
        <div>
            <BarChart  width={400} height={400} data={accounts}>                  
                return (
                    <>
                        <YAxis />
                        <Tooltip />
                        {/* <Legend payload={[{ value: 'date', type: 'line' }]} /> */}
                        <XAxis dataKey="date" /> 
                        <Bar type="monotone" dataKey="value"
                            label={{ position: 'top' }} 
                            fill={currentColor} />
                    </>
                )   
            </BarChart >
        </div>
    )
}
 {/* <Bar type="monotone" dataKey="valor" stackId="1" fill="cor" >
                    {
                        listaContas.map(v => {
                            return <Cell fill={v.cor} />;
                        })
                    }
                </Bar> */}
                {/* <Bar type="monotone" dataKey="valor2" stackId={1} fill="blue" /> */}
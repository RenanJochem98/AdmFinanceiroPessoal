// import * as React from "react";
import { FieldValues, UseFormRegister } from "react-hook-form";
import { IDefaultInput } from "../../../types/IDefaultInput"

interface IInputNumberProps extends IDefaultInput {
    register?: UseFormRegister<FieldValues>
    // registerName?: string
}
// Estudar sobre React.forwardRef 
export default function InputNumber({register, ...rest}: IInputNumberProps){
    return (
        <>
            <input
                // {...rest}
                {...(register )}
                type="number" 
                placeholder={rest.placeholder} 
                className={"border-b-2 w-full my-2 " + (rest.className == null ? "" : rest.className)}
            />
        </>
    )
}
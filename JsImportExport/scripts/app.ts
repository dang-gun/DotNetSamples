
import { TsTestI1 } from "./TsTest01";
import { TsTestI2 } from "./TsTest02";


export default function AppStart()
{
    let temp: Start = new Start();
}

export class Start
{
    constructor()
    {
        let t02: TsTestI2 = { Ts1: "111", Ts2: 1, Ts3: true };
        let t01: TsTestI1 = t02 as TsTestI1;


        console.log(t01);
        console.log(t02);
    }
    
}

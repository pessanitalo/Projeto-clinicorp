import { Paciente } from "./paciente";

export interface Medico{
    id:number,
    nome:string,
    crm:number,
    cpf:string,
    especializacao:string,
    paciente: Paciente,
    
}
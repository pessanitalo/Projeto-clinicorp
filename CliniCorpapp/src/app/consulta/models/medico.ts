import { Paciente } from "./paciente";

export interface Medico{
    id:number,
    nome:string,
    crm:number,
    cpf:string,
    paciente: Paciente,
    
}
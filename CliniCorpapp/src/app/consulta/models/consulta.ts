import { Medico } from "./medico";
import { Paciente } from "./paciente";

export interface Consulta {
    id: number,
    paciente: Paciente,
    medico: Medico,
    dataConsulta: Date,
    descricaoConsulta: string,
    MedicoEspecialista: number,
    statusConsulta: number,
    nome:string,
    especializacao:number,
    nomePaciente: string,
    status: string
}
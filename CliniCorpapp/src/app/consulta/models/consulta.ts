import { Medico } from "./medico";
import { Paciente } from "./paciente";

export interface Consulta {
    id: number,
    paciente: Paciente,
    medico: Medico,
    dataConsulta: Date,
    descricaoConsulta: string,
    status: number,
    statusConsulta: string,
    medicoId: number,
    pacienteId: number
}